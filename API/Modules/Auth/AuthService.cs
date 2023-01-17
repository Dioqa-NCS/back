using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using API.Modules.Auth.Ressources;
using System.IdentityModel.Tokens.Jwt;
using API.Modules.Auth.Settings;

namespace API.Modules.Auth;

public class AuthService : IAuthService
{
    private readonly SignInManager<Compte> _signInManager;
    private readonly JWTSettings _jWTSetting;
    private readonly HttpContext _httpContext;


    public AuthService(
        SignInManager<Compte> signInManager,
        IOptionsSnapshot<JWTSettings> jWTSetting,
        IHttpContextAccessor httpContextAccessor)

    {
        _signInManager = signInManager;
        _jWTSetting = jWTSetting.Value;
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

        return new SigninRessponse(roles);
    }



    public async Task<Compte?> SignupAsync(Compte compte)
    {
        Compte? userCreate = null;
        try
        {
            await _signInManager.UserManager.CreateAsync(compte, compte.Mdp);
            userCreate = await _signInManager.UserManager.FindByEmailAsync(compte.UserName);

            if(userCreate == null)
            {
                return null;
            }

            await _signInManager.UserManager.AddToRoleAsync(userCreate, "Client");
            return userCreate;
        }
        catch(Exception ex)
        {
            if(userCreate is not null)
            {
                await _signInManager.UserManager.DeleteAsync(userCreate);
            }

            throw new Exception(ex.Message, ex);
        }
    }


    private async Task CreateCookieAuthAsync(List<Claim> claims)
    {
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
        identity.AddClaims(claims);
        var principal = new ClaimsPrincipal(identity);


        await this._httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.AddDays(Convert.ToDouble(this._jWTSetting.Expiry)),
            });
    }


    private List<Claim> CreateClaims(Compte user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
        claims.AddRange(roleClaims);

        return claims;
    }
}
