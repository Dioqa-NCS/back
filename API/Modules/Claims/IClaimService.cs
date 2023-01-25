using System.Security.Claims;

namespace API.Modules.Claims;

public interface IClaimService
{
    public List<Claim> CreateClaims(Compte user, IEnumerable<string> roles);

    public Task SigninAsync(List<Claim> claims);

    public Task SignoutAsync();

    public string FindSub();
}
