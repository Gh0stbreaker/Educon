using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IStudentProfileService : IGenericService<StudentProfile>
{
    Task<IEnumerable<StudentProfile>> GetStudentsByClassAsync(
        Guid classId,
        CancellationToken cancellationToken = default);

    Task<StudentProfile?> GetStudentWithParentsAsync(
        Guid studentId,
        CancellationToken cancellationToken = default);
}
