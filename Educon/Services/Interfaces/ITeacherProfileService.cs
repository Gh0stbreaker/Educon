using Educon.Models;

namespace Educon.Services.Interfaces;

public interface ITeacherProfileService : IGenericService<TeacherProfile>
{
    Task<IEnumerable<TeacherProfile>> GetTeachersBySchoolAsync(
        Guid schoolId,
        CancellationToken cancellationToken = default);
}
