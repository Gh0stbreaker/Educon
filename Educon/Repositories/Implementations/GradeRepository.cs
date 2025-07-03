using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class GradeRepository : Repository<Grade>, IGradeRepository
{
    public GradeRepository(EduconContext context, ILogger<GradeRepository> logger) : base(context, logger) { }
}
