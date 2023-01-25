using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using API.Modules.Auth.Ressources;
using API.Modules.Claims;

namespace API.Modules.Auth;

public class AuthService : IAuthService
{
    private readonly SignInManager<Compte> _signInManager;
    private readonly IClaimService _claimService;

    public AuthService(
        SignInManager<Compte> signInManager,
        IClaimService claimService)

    {
        _signInManager = signInManager;
        _claimService = claimService;
    }

    public async Task SignoutAsync()
    {
        await _claimService.SignoutAsync();
    }

    public async Task<SigninRessponse?> SignInAsync(Compte user)
    {
       
        var roles = await _signInManager.UserManager.GetRolesAsync(user);

        var claims = _claimService.CreateClaims(user, roles);

        await _claimService.SigninAsync(claims);

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
}
