using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class SubjectTeacherService : GenericService<SubjectTeacher>, ISubjectTeacherService
{
    public SubjectTeacherService(ISubjectTeacherRepository repository) : base(repository) { }
}
