using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using API.Modules.Auth.Ressources;
using System.IdentityModel.Tokens.Jwt;

namespace API.Modules.Auth;

public class AuthService : IAuthService
{
    private readonly SignInManager<Compte> _signInManager;
    private readonly HttpContext _httpContext;


    public AuthService(
        SignInManager<Compte> signInManager,
        IHttpContextAccessor httpContextAccessor)

    {
        _signInManager = signInManager;
        _httpContext = httpContextAccessor.HttpContext;
    }

    public async Task SignoutAsync()
    {
        await _httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public async Task<SigninRessponse?> SignInAsync(Compte user)
    {
       
        var roles = await _signInManager.UserManager.GetRolesAsync(user);

        var claims = CreateClaims(user, roles);

        await CreateCookieAuthAsync(claims);

        await _signInManager.UserManager.UpdateAsync(user);

        return new SigninRessponse { Roles = roles };
    }

    

    public async Task<Compte?> SignupAsync(Compte compte)
    {
       await _signInManager.UserManager.CreateAsync(compte, compte.Mdp);

        var userCreate = await _signInManager.UserManager.FindByEmailAsync(compte.UserName);

        await _signInManager.UserManager.AddToRoleAsync(userCreate, AuthRole.Customer);

        return userCreate;
    }


    private async Task CreateCookieAuthAsync(List<Claim> claims)
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


    private List<Claim> CreateClaims(Compte user, IEnumerable<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
        };

        var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
        claims.AddRange(roleClaims);

        return claims;
    }
}
