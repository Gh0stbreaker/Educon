using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class GradeLevelService : GenericService<GradeLevel>, IGradeLevelService
{
    public GradeLevelService(IGradeLevelRepository repository) : base(repository) { }
}
