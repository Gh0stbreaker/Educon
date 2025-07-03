using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class StudentParentService : GenericService<StudentParent>, IStudentParentService
{
    public StudentParentService(IStudentParentRepository repository) : base(repository) { }
}
