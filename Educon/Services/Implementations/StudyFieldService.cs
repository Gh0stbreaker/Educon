using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class StudyFieldService : GenericService<StudyField>, IStudyFieldService
{
    public StudyFieldService(IStudyFieldRepository repository) : base(repository) { }
}
