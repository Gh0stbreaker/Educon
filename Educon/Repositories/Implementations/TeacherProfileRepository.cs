using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class TeacherProfileRepository : Repository<TeacherProfile>, ITeacherProfileRepository
{
    public TeacherProfileRepository(EduconContext context, ILogger<TeacherProfileRepository> logger) : base(context, logger) { }
}
