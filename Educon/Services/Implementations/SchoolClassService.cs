using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class SchoolClassService : GenericService<SchoolClass>, ISchoolClassService
{
    public SchoolClassService(ISchoolClassRepository repository) : base(repository) { }
}
