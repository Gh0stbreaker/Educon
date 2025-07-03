using Educon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using Educon.Models;

namespace Educon.Repositories;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly EduconContext _context;
    private readonly DbSet<T> _dbSet;
    private readonly ILogger<Repository<T>> _logger;

    public Repository(EduconContext context, ILogger<Repository<T>> logger)
    {
        _context = context;
        _dbSet = context.Set<T>();
        _logger = logger;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding {EntityType}", typeof(T).Name);
            throw;
        }
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                _logger.LogWarning("Entity {EntityType} with id {Id} not found for deletion", typeof(T).Name, id);
                return;
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting {EntityType} with id {Id}", typeof(T).Name, id);
            throw;
        }
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _dbSet
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error finding {EntityType} entities", typeof(T).Name);
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool ascending = true,
        string? searchTerm = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = ApplySearch(query, searchTerm);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving {EntityType} with query", typeof(T).Name);
            throw;
        }
    }

    public async Task<PagedResult<T>> GetPagedAsync(
        int page,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool ascending = true,
        string? searchTerm = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes)
    {
        try
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 1 : pageSize;

            IQueryable<T> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = ApplySearch(query, searchTerm);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PagedResult<T>(items, totalCount, page, pageSize);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving paged {EntityType}", typeof(T).Name);
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all {EntityType}", typeof(T).Name);
            throw;
        }
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving {EntityType} with id {Id}", typeof(T).Name, id);
            throw;
        }
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating {EntityType} with id {Id}", typeof(T).Name, GetEntityId(entity));
            throw;
        }
    }

    private static IQueryable<T> ApplySearch(IQueryable<T> query, string searchTerm)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        Expression? combined = null;
        var toLower = typeof(string).GetMethod(nameof(string.ToLower), Type.EmptyTypes)!;
        var contains = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!;
        var searchConstant = Expression.Constant(searchTerm.ToLower());

        foreach (var prop in typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string)))
        {
            var access = Expression.Property(parameter, prop);
            var notNull = Expression.NotEqual(access, Expression.Constant(null, typeof(string)));
            var lower = Expression.Call(access, toLower);
            var containsCall = Expression.Call(lower, contains, searchConstant);
            var expression = Expression.AndAlso(notNull, containsCall);
            combined = combined == null ? expression : Expression.OrElse(combined, expression);
        }

        if (combined != null)
        {
            var lambda = Expression.Lambda<Func<T, bool>>(combined, parameter);
            query = query.Where(lambda);
        }

        return query;
    }

    private static Guid GetEntityId(T entity)
    {
        return entity.Id;
    }
}
