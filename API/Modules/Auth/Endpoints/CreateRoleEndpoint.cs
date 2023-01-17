using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth.Endpoints;

public static class CreateRoleEndpoint
{
    public static async Task<IResult> CreateRole(
        [FromServices] RoleManager<IdentityRole<int>> roleManager,
        string roleName
        )
    {
        if(string.IsNullOrWhiteSpace(roleName))
        {
            return Results.BadRequest("Role name should be provided.");
        }

        var newRole = new IdentityRole<int>
        {
            Name = roleName
        };

        var roleResult = await roleManager.CreateAsync(newRole);

        if(!roleResult.Succeeded)
        {
            return Results.Problem(roleResult.Errors.First().Description, null, 500);
        }

        return Results.Ok();
    }
}
