using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class TeacherProfileService : GenericService<TeacherProfile>, ITeacherProfileService
{
    private readonly ITeacherProfileRepository _repository;
    private readonly ITeacherSchoolAssignmentRepository _assignmentRepository;

    public TeacherProfileService(
        ITeacherProfileRepository repository,
        ITeacherSchoolAssignmentRepository assignmentRepository) : base(repository)
    {
        _repository = repository;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<IEnumerable<TeacherProfile>> GetTeachersBySchoolAsync(Guid schoolId, CancellationToken cancellationToken = default)
    {
        var assignments = await _assignmentRepository.GetAsync(a => a.SchoolId == schoolId, cancellationToken: cancellationToken);
        var teacherIds = assignments.Select(a => a.TeacherId).Distinct();
        return await _repository.GetAsync(t => teacherIds.Contains(t.Id), cancellationToken: cancellationToken, includes: t => t.Profile!);
    }
}
