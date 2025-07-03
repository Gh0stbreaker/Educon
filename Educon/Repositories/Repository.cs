using Educon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Educon.Repositories;

public class Repository<T> : IRepository<T> where T : class
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

    public async Task<T> AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding {EntityType}", typeof(T).Name);
            throw;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning("Entity {EntityType} with id {Id} not found for deletion", typeof(T).Name, id);
                return;
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting {EntityType} with id {Id}", typeof(T).Name, id);
            throw;
        }
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error finding {EntityType} entities", typeof(T).Name);
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all {EntityType}", typeof(T).Name);
            throw;
        }
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        try
        {
            return await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving {EntityType} with id {Id}", typeof(T).Name, id);
            throw;
        }
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating {EntityType} with id {Id}", typeof(T).Name, GetEntityId(entity));
            throw;
        }
    }

    private static Guid? GetEntityId(T entity)
    {
        var prop = typeof(T).GetProperty("Id");
        if (prop != null && prop.PropertyType == typeof(Guid))
        {
            return (Guid?)prop.GetValue(entity);
        }
        return null;
    }
}
