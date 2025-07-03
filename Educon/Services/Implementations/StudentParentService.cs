using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class StudentParentService : GenericService<StudentParent>, IStudentParentService
{
    private readonly IStudentParentRepository _repository;

    public StudentParentService(IStudentParentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StudentParent>> GetByStudentAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(
            sp => sp.StudentId == studentId,
            cancellationToken: cancellationToken,
            includes: sp => sp.Student!, sp => sp.Parent!);
    }

    public Task<IEnumerable<StudentParent>> GetByParentAsync(Guid parentId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(
            sp => sp.ParentId == parentId,
            cancellationToken: cancellationToken,
            includes: sp => sp.Student!, sp => sp.Parent!);
    }
}
