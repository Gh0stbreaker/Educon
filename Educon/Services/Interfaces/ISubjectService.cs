using Educon.Models;

namespace Educon.Services.Interfaces;

public interface ISubjectService : IGenericService<Subject>
{
    Task<IEnumerable<Subject>> GetByTypeAsync(
        SubjectType type,
        CancellationToken cancellationToken = default);
}
