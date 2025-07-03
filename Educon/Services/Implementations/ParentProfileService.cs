using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class ParentProfileService : GenericService<ParentProfile>, IParentProfileService
{
    public ParentProfileService(IParentProfileRepository repository) : base(repository) { }
}
