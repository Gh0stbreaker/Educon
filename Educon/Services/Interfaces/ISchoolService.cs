using Educon.Models;

namespace Educon.Services.Interfaces;

public interface ISchoolService : IGenericService<School>
{
    Task<PagedResult<School>> GetSchoolsAsync(
        int page,
        int pageSize,
        string? search,
        string? sortBy,
        bool ascending = true,
        SchoolType? type = null,
        SchoolStatus? status = null,
        SchoolLevel? level = null,
        CancellationToken cancellationToken = default);
}
