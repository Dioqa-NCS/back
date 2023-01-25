using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Modules.Claims;

public class ClaimService : IClaimService
{

    private readonly HttpContext _httpContext;

    public ClaimService(
        IHttpContextAccessor httpContextAccessor
        )
    {
        _httpContext = httpContextAccessor.HttpContext;
    }

    public List<Claim> CreateClaims(Compte user, IEnumerable<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
        };

        var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
        claims.AddRange(roleClaims);

        return claims;
    }

    public string FindSub() => _httpContext.User.Claims.FirstOrDefault(
            claim => claim.Type == JwtRegisteredClaimNames.Sub
            ).Value;

    public async Task SigninAsync(List<Claim> claims)
    {
        var identity = new ClaimsIdentity(
            CookieAuthenticationDefaults.AuthenticationScheme,
            ClaimTypes.Name,
            ClaimTypes.Role
            );

        identity.AddClaims(claims);

        await _httpContext.SignInAsync(
            scheme: CookieAuthenticationDefaults.AuthenticationScheme,
            principal: new ClaimsPrincipal(identity),
            properties: new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.AddDays(Convert.ToDouble(Environment.GetEnvironmentVariable("COOKIE_EXPIRY"))),
            });
    }

    public async Task SignoutAsync()
    {
        await _httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
