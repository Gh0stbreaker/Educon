using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class ProfileRepository : Repository<Profile>, IProfileRepository
{
    public ProfileRepository(EduconContext context, ILogger<ProfileRepository> logger) : base(context, logger) { }
}
