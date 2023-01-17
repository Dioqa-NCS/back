namespace API.Modules.Auth.Endpoints;

public class SignoutEndpoint
{
    public static async Task<IResult> signout([FromServices] IAuthService authService)
    {
        await authService.SignoutAsync();
        return Results.NoContent();
    }
}
