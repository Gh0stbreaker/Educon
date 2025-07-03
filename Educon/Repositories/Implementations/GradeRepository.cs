using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class GradeRepository : Repository<Grade>, IGradeRepository
{
    public GradeRepository(EduconContext context, ILogger<GradeRepository> logger) : base(context, logger) { }
}
