using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class StudyFieldService : GenericService<StudyField>, IStudyFieldService
{
    private readonly IStudyFieldRepository _repository;

    public StudyFieldService(IStudyFieldRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StudyField>> GetByTypeAsync(StudyFieldType type, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(sf => sf.Type == type, cancellationToken: cancellationToken);
    }
}
