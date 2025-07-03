using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class TeacherSchoolAssignmentRepository : Repository<TeacherSchoolAssignment>, ITeacherSchoolAssignmentRepository
{
    public TeacherSchoolAssignmentRepository(EduconContext context, ILogger<TeacherSchoolAssignmentRepository> logger) : base(context, logger) { }
}
