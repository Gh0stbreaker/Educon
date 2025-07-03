using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class SchoolYearService : GenericService<SchoolYear>, ISchoolYearService
{
    public SchoolYearService(ISchoolYearRepository repository) : base(repository) { }
}
