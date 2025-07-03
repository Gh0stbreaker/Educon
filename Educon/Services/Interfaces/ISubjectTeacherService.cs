using Educon.Models;

namespace Educon.Services.Interfaces;

public interface ISubjectTeacherService : IGenericService<SubjectTeacher>
{
    Task<IEnumerable<SubjectTeacher>> GetByTeacherAsync(
        Guid teacherId,
        CancellationToken cancellationToken = default);
}
