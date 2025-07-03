using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class ParentProfileRepository : Repository<ParentProfile>, IParentProfileRepository
{
    public ParentProfileRepository(EduconContext context, ILogger<ParentProfileRepository> logger) : base(context, logger) { }
}
