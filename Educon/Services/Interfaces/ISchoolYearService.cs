using Educon.Models;

namespace Educon.Services.Interfaces;

public interface ISchoolYearService : IGenericService<SchoolYear>
{
    Task<SchoolYear?> GetCurrentYearAsync(
        CancellationToken cancellationToken = default);
}
