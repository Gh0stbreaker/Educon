using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class SchoolClassRepository : Repository<SchoolClass>, ISchoolClassRepository
{
    public SchoolClassRepository(EduconContext context, ILogger<SchoolClassRepository> logger) : base(context, logger) { }
}
