using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class StudentProfileService : GenericService<StudentProfile>, IStudentProfileService
{
    public StudentProfileService(IStudentProfileRepository repository) : base(repository) { }
}
