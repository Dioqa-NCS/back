namespace API.Modules.Auth.Endpoints;

public class SignoutEndpoint
{
    public const string Description = "Déconnexion de l'API NCS.";

    public static async Task<IResult> Signout([FromServices] IAuthService authService)
    {
        await authService.SignoutAsync();
        return Results.NoContent();
    }
}
