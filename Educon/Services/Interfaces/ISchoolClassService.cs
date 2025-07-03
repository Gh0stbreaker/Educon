using Educon.Models;

namespace Educon.Services.Interfaces;

public interface ISchoolClassService : IGenericService<SchoolClass>
{
    Task<IEnumerable<SchoolClass>> GetClassesBySchoolAsync(
        Guid schoolId,
        CancellationToken cancellationToken = default);
}
