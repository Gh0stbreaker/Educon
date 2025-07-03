using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class ApplicationUserService : GenericService<ApplicationUser>, IApplicationUserService
{
    public ApplicationUserService(IApplicationUserRepository repository) : base(repository) { }
}
