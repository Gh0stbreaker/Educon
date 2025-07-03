using System.Linq;
using Educon.Models;
using Educon.Repositories.Interfaces;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class ApplicationUserService : GenericService<ApplicationUser>, IApplicationUserService
{
    private readonly IApplicationUserRepository _repository;

    public ApplicationUserService(IApplicationUserRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<ApplicationUser?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(
            u => u.Email == email,
            cancellationToken: cancellationToken,
            includes: u => u.Profile);

        return result.FirstOrDefault();
    }
}
