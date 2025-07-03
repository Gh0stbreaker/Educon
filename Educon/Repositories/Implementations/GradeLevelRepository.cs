using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class GradeLevelRepository : Repository<GradeLevel>, IGradeLevelRepository
{
    public GradeLevelRepository(EduconContext context, ILogger<GradeLevelRepository> logger) : base(context, logger) { }
}
