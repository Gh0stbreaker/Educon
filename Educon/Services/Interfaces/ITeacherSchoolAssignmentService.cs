using Educon.Models;

namespace Educon.Services.Interfaces;

public interface ITeacherSchoolAssignmentService : IGenericService<TeacherSchoolAssignment>
{
    Task<IEnumerable<TeacherSchoolAssignment>> GetAssignmentsByTeacherAsync(
        Guid teacherId,
        CancellationToken cancellationToken = default);
}
