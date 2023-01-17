using API.Modules.Auth.Ressources;
using System.Security.Claims;

namespace API.Modules.Auth.Endpoints;

public static class CheckauthEndpoint
{
    public static IResult checkAuth(HttpContext context)
    {
        var nameClaime = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);
        var roles = context.User.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList();
        
        return Results.Ok(new SignedinResponse(
            username: nameClaime?.Value,
            authentificated: context.User?.Identity?.IsAuthenticated ?? false,
            roles: roles.Any() ? roles : null
            ));
    }
}
