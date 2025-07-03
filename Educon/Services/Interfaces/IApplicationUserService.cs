using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IApplicationUserService : IGenericService<ApplicationUser>
{
    Task<ApplicationUser?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);
}
