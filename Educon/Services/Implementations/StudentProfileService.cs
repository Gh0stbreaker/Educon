using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class StudentProfileService : GenericService<StudentProfile>, IStudentProfileService
{
    private readonly IStudentProfileRepository _repository;

    public StudentProfileService(IStudentProfileRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StudentProfile>> GetStudentsByClassAsync(Guid classId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(sp => sp.ClassId == classId, cancellationToken: cancellationToken, includes: sp => sp.Profile!);
    }

    public async Task<StudentProfile?> GetStudentWithParentsAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(
            sp => sp.Id == studentId,
            cancellationToken: cancellationToken,
            includes: sp => sp.Profile!,
            sp => sp.ParentsLinks);

        return result.FirstOrDefault();
    }
}
