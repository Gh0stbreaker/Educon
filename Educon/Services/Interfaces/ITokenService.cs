using Educon.Models;

namespace Educon.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(ApplicationUser user);
}
