using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class TeacherProfileService : GenericService<TeacherProfile>, ITeacherProfileService
{
    public TeacherProfileService(ITeacherProfileRepository repository) : base(repository) { }
}
