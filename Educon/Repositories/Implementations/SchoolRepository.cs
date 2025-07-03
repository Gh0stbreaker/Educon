using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class SchoolRepository : Repository<School>, ISchoolRepository
{
    public SchoolRepository(EduconContext context, ILogger<SchoolRepository> logger) : base(context, logger) { }
}
