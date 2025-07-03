using Educon.Models;
using Educon.Repositories.Interfaces;

using Educon.Services.Interfaces;
namespace Educon.Services.Implementations;

public class SchoolClassService : GenericService<SchoolClass>, ISchoolClassService
{
    private readonly ISchoolClassRepository _repository;

    public SchoolClassService(ISchoolClassRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<SchoolClass>> GetClassesBySchoolAsync(Guid schoolId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(c => c.SchoolId == schoolId, cancellationToken: cancellationToken, includes: c => c.GradeLevel!, c => c.StudyField!, c => c.SchoolYear!);
    }
}
