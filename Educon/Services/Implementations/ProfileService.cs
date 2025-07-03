using System.Linq;
using Educon.Models;
using Educon.Repositories.Interfaces;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class ProfileService : GenericService<Profile>, IProfileService
{
    private readonly IProfileRepository _repository;

    public ProfileService(IProfileRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Profile?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(
            p => p.User.Id == userId,
            cancellationToken: cancellationToken,
            includes: p => p.User,
            p => p.StudentProfile,
            p => p.TeacherProfile,
            p => p.ParentProfile);

        return result.FirstOrDefault();
    }
}
