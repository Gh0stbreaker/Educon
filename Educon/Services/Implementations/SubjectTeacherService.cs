using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class SubjectTeacherService : GenericService<SubjectTeacher>, ISubjectTeacherService
{
    private readonly ISubjectTeacherRepository _repository;

    public SubjectTeacherService(ISubjectTeacherRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<SubjectTeacher>> GetByTeacherAsync(Guid teacherId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(
            st => st.TeacherId == teacherId,
            cancellationToken: cancellationToken,
            includes: st => st.Subject, st => st.Teacher);
    }
}
