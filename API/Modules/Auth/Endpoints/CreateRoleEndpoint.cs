using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth.Endpoints;

public static class CreateRoleEndpoint
{
    public const string Description = "Création d'un role utilisateur.";

    public static async Task<IResult> CreateRole(
        [FromServices] RoleManager<IdentityRole<int>> roleManager,
        string roleName
        )
    {
        if(string.IsNullOrWhiteSpace(roleName))
        {
            return Results.BadRequest("Role name should be provided.");
        }

        var roleResult = await roleManager.CreateAsync(
            role: new IdentityRole<int>
            {
                Name = roleName
            });

        if(!roleResult.Succeeded)
        {
            return Results.Problem(roleResult.Errors.First().Description, null, 500);
        }

        return Results.Ok();
    }
}
