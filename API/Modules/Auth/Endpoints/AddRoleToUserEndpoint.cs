using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth.Endpoints;

public static class AddRoleToUserEndpoint
{
    public const string Description = "Ajout d'un role à un compte existant.";

    public static async Task<IResult> addRoleToUser(
        [FromServices] UserManager<Compte> userManager,
        string userEmail, 
        [FromBody] string roleName
        )
    {
        var user = userManager.Users.SingleOrDefault(u => u.UserName == userEmail);


        if(user == null)
        {
            return Results.BadRequest(new ErrorMessage(message: "Aucun utilisateur trouvé.").GetError());
        }

        var result = await userManager.AddToRoleAsync(user, roleName);

        if(!result.Succeeded)
        {
            return Results.Problem(result.Errors.First().Description, null, 500);
        }



        return Results.Created(string.Empty, roleName);

    }
}
