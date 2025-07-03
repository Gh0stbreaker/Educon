using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class GradeService : GenericService<Grade>, IGradeService
{
    public GradeService(IGradeRepository repository) : base(repository) { }
}
