using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class StudentProfileRepository : Repository<StudentProfile>, IStudentProfileRepository
{
    public StudentProfileRepository(EduconContext context, ILogger<StudentProfileRepository> logger) : base(context, logger) { }
}
