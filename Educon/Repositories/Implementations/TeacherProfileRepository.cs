using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class TeacherProfileRepository : Repository<TeacherProfile>, ITeacherProfileRepository
{
    public TeacherProfileRepository(EduconContext context, ILogger<TeacherProfileRepository> logger) : base(context, logger) { }
}
