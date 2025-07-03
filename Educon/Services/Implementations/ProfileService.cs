using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class ProfileService : GenericService<Profile>, IProfileService
{
    public ProfileService(IProfileRepository repository) : base(repository) { }
}
