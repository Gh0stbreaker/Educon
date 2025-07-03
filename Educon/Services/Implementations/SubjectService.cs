using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;

namespace Educon.Services.Implementations;

public class SubjectService : GenericService<Subject>, ISubjectService
{
    private readonly ISubjectRepository _repository;

    public SubjectService(ISubjectRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Subject>> GetByTypeAsync(SubjectType type, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(s => s.SubjectType == type, cancellationToken: cancellationToken);
    }
}
