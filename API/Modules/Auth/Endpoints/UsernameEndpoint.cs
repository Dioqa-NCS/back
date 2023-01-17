using API.Modules.Auth.Ressources;
using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth.Endpoints;

public static class UsernameEndpoint
{
    public static async Task<IResult> username(
            [FromServices] UserManager<Compte> userManager,
            [FromBody] AvailableUsernameRequest usernameRequest
            )
    {
        var user = await userManager.FindByNameAsync(usernameRequest.UserName);
        return Results.Ok(new AvailableUsernameResponse(available: user != null));
    }
}
