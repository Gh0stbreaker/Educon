using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IProfileService : IGenericService<Profile>
{
    Task<Profile?> GetByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
}
