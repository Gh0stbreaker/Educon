using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IParentProfileService : IGenericService<ParentProfile>
{
    Task<IEnumerable<ParentProfile>> GetParentsByStudentAsync(
        Guid studentId,
        CancellationToken cancellationToken = default);
}
