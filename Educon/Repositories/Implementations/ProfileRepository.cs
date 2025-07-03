using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class ProfileRepository : Repository<Profile>, IProfileRepository
{
    public ProfileRepository(EduconContext context, ILogger<ProfileRepository> logger) : base(context, logger) { }
}
