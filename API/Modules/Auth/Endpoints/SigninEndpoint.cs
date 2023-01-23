using API.Modules.Auth.Ressources;
using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth.Endpoints;

public class SigninEndpoint
{
    public const string Description = "Authentification à l'API NCS.";
    public static async Task<IResult> signin(
            [FromServices] IAuthService authService,
            [FromServices] UserManager<Compte> userManager,
            [FromBody] SigninRequest signinRequest
            )
    {
        var compte = await userManager.FindByEmailAsync(signinRequest.Username);

        if(compte is null || !await userManager.CheckPasswordAsync(compte, signinRequest.Password))
        {
            return Results.Unauthorized();
        }
        
        if(!compte.IsEnable())
        {

            return Results.Conflict(new ErrorMessage(message: "Le compte est désactivé.").GetError());
        }

        var authSigninResponse = await authService.SignInAsync(compte);

        return Results.Ok(authSigninResponse);
    }
}
