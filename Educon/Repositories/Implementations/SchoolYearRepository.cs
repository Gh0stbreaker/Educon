using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class SchoolYearRepository : Repository<SchoolYear>, ISchoolYearRepository
{
    public SchoolYearRepository(EduconContext context, ILogger<SchoolYearRepository> logger) : base(context, logger) { }
}
