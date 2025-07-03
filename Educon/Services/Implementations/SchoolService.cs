using System.Linq.Expressions;
using Educon.Models;
using Educon.Repositories;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class SchoolService : Service<School>, ISchoolService
{
    private readonly ISchoolRepository _repository;

    public SchoolService(ISchoolRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<PagedResult<School>> GetSchoolsAsync(
        int page,
        int pageSize,
        string? search,
        string? sortBy,
        bool ascending = true,
        SchoolType? type = null,
        SchoolStatus? status = null,
        SchoolLevel? level = null,
        CancellationToken cancellationToken = default)
    {
        Expression<Func<School, bool>>? filter = null;
        if (type.HasValue || status.HasValue || level.HasValue)
        {
            filter = s =>
                (!type.HasValue || s.Type == type.Value) &&
                (!status.HasValue || s.Status == status.Value) &&
                (!level.HasValue || s.Level == level.Value);
        }

        Expression<Func<School, object>>? orderBy = null;
        if (!string.IsNullOrEmpty(sortBy))
        {
            orderBy = sortBy.ToLower() switch
            {
                "name" => s => s.Name,
                "type" => s => s.Type,
                "level" => s => s.Level,
                "status" => s => s.Status,
                "address" => s => s.Address,
                "email" => s => s.Email!,
                "phone" => s => s.Phone!,
                "ico" => s => s.Ico!,
                "director" => s => s.Director!,
                _ => null
            };
        }

        return _repository.GetPagedAsync(page, pageSize, filter, orderBy, ascending, search, cancellationToken);
    }
}
