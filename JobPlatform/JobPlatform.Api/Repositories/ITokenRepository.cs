using Microsoft.AspNetCore.Identity;

namespace JobPlatform.Api.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user,List<string> roles);
    }
}
