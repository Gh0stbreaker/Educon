using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IStudentParentService : IGenericService<StudentParent>
{
    Task<IEnumerable<StudentParent>> GetByStudentAsync(
        Guid studentId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<StudentParent>> GetByParentAsync(
        Guid parentId,
        CancellationToken cancellationToken = default);
}
