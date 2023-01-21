using API.Modules.Auth.Ressources;
using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth.Endpoints;

public class SigninEndpoint
{
    public const string Description = "Authentification à l'API NCS.";
    public static async Task<IResult> signin(
            [FromServices] IAuthService authService,
            [FromServices] UserManager<Compte> userManager,
            [FromBody] SigninRequest authSigninRequest
            )
    {
        var user = await userManager.FindByEmailAsync(authSigninRequest.Username);

        if(user == null || !await userManager.CheckPasswordAsync(user, authSigninRequest.Password))
        {
            return Results.Unauthorized();
        }

        if(user.EstValider == "O")
        {

            return Results.Conflict(new ErrorMessage(message: "Le compte est désactivé.").GetError());
        }

        var authSigninResponse = await authService.SignInAsync(user);

        return Results.Ok(authSigninResponse);
    }
}
