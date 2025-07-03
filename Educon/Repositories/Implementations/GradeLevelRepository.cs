using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class GradeLevelRepository : Repository<GradeLevel>, IGradeLevelRepository
{
    public GradeLevelRepository(EduconContext context, ILogger<GradeLevelRepository> logger) : base(context, logger) { }
}
