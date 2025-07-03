using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class TeacherSchoolAssignmentService : GenericService<TeacherSchoolAssignment>, ITeacherSchoolAssignmentService
{
    public TeacherSchoolAssignmentService(ITeacherSchoolAssignmentRepository repository) : base(repository) { }
}
