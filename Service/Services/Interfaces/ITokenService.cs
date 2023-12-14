using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(AppUser user, List<string> roles);
    }
}
