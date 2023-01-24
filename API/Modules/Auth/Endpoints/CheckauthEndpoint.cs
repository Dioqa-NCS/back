using API.Modules.Auth.Ressources;
using System.Security.Claims;

namespace API.Modules.Auth.Endpoints;

public static class CheckauthEndpoint
{
    public const string Description = "Vérifie si l'utilisateur courrant est connecté à l'API.";

    public static IResult CheckAuth(HttpContext context)
    {
        // C'est au auth sercices de gérer cela
        var nameClaime = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);
        var roles = context.User.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList();
        
        return Results.Ok(new SignedinResponse(
            username: nameClaime?.Value,
            authentificated: context.User.Identity?.IsAuthenticated ?? false,
            roles: roles.Any() ? roles : null
            ));
    }
}
