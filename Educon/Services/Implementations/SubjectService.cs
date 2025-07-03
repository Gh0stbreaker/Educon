using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class SubjectService : GenericService<Subject>, ISubjectService
{
    public SubjectService(ISubjectRepository repository) : base(repository) { }
}
