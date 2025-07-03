using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class TeacherSchoolAssignmentService : GenericService<TeacherSchoolAssignment>, ITeacherSchoolAssignmentService
{
    private readonly ITeacherSchoolAssignmentRepository _repository;

    public TeacherSchoolAssignmentService(ITeacherSchoolAssignmentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<TeacherSchoolAssignment>> GetAssignmentsByTeacherAsync(Guid teacherId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(
            a => a.TeacherId == teacherId,
            cancellationToken: cancellationToken,
            includes: a => a.School, a => a.Teacher);
    }
}
