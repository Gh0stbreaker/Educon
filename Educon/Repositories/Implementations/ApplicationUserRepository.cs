using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(EduconContext context, ILogger<ApplicationUserRepository> logger) : base(context, logger) { }
}
