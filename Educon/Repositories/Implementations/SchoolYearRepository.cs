using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class SchoolYearRepository : Repository<SchoolYear>, ISchoolYearRepository
{
    public SchoolYearRepository(EduconContext context, ILogger<SchoolYearRepository> logger) : base(context, logger) { }
}
