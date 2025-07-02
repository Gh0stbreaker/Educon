using Microsoft.AspNetCore.Identity;

namespace Educon.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; } = null!;
}
