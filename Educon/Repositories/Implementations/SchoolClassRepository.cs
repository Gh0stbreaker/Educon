using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class SchoolClassRepository : Repository<SchoolClass>, ISchoolClassRepository
{
    public SchoolClassRepository(EduconContext context, ILogger<SchoolClassRepository> logger) : base(context, logger) { }
}
