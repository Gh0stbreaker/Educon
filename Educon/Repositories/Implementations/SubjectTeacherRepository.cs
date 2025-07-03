using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class SubjectTeacherRepository : Repository<SubjectTeacher>, ISubjectTeacherRepository
{
    public SubjectTeacherRepository(EduconContext context, ILogger<SubjectTeacherRepository> logger) : base(context, logger) { }
}
