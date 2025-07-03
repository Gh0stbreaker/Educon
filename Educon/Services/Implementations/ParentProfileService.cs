using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;

namespace Educon.Services.Implementations;

public class ParentProfileService : GenericService<ParentProfile>, IParentProfileService
{
    private readonly IParentProfileRepository _repository;

    public ParentProfileService(IParentProfileRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ParentProfile>> GetParentsByStudentAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(
            p => p.ChildrenLinks.Any(link => link.StudentId == studentId),
            cancellationToken: cancellationToken,
            includes: p => p.Profile!);
    }
}
