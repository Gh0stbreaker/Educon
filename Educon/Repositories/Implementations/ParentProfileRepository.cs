using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class ParentProfileRepository : Repository<ParentProfile>, IParentProfileRepository
{
    public ParentProfileRepository(EduconContext context, ILogger<ParentProfileRepository> logger) : base(context, logger) { }
}
