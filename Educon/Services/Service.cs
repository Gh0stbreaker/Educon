using System.Linq.Expressions;
using Educon.Models;
using Educon.Repositories;

namespace Educon.Services;

public class Service<T> : IService<T> where T : class, IEntity
{
    private readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        return _repository.AddAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }

    public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _repository.FindAsync(predicate, cancellationToken);
    }

    public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>? orderBy = null, bool ascending = true, string? searchTerm = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
    {
        return _repository.GetAsync(filter, orderBy, ascending, searchTerm, cancellationToken, includes);
    }

    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
    {
        return _repository.GetByIdAsync(id, cancellationToken, includes);
    }

    public Task<PagedResult<T>> GetPagedAsync(int page, int pageSize, Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>? orderBy = null, bool ascending = true, string? searchTerm = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
    {
        return _repository.GetPagedAsync(page, pageSize, filter, orderBy, ascending, searchTerm, cancellationToken, includes);
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        return _repository.UpdateAsync(entity, cancellationToken);
    }
}
