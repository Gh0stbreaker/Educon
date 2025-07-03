using System.Linq;
using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class GradeService : GenericService<Grade>, IGradeService
{
    private readonly IGradeRepository _repository;

    public GradeService(IGradeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Grade>> GetGradesByStudentAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(
            g => g.StudentId == studentId,
            cancellationToken: cancellationToken,
            includes: g => g.Student!, g => g.SubjectTeacher);
    }
}
