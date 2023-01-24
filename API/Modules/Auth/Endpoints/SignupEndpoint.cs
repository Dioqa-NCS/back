using API.Modules.Auth.Ressources;
using API.Modules.Shared;

namespace API.Modules.Auth.Endpoints;

public static class SignupEndpoint
{
    public const string Description = "Demande de compte d'utilisation l'API NCS.";

    public static async Task<IResult> Signup(
            [FromServices] IAuthService authService,
            [FromServices] IMailService mailService,
            [FromServices] IMapper mapper,
            [FromServices] IValidator<SignupRequest> validator,
            [FromBody] SignupRequest signupRequest)
    {
        var validationResult = await validator.ValidateAsync(signupRequest);

        if(!validationResult.IsValid)
        {
            return Results.BadRequest(new ErrorMessage(message: "Les champs renseignés sont incorrects.", errorMessages: validationResult.Errors).GetError());
        }

        var user = mapper.Map<SignupRequest, Compte>(signupRequest);

        var userCreate = await authService.SignupAsync(user);

        if(userCreate == null)
        {
            return Results.Problem(title: "Utilisateur null après la création de l'utilisateur");
        }

        await mailService.SendEmailAsync(user.Email, "Creation du compte", "Welcom Client1");

        return Results.Created("URIEIEIEI", new SignupResponse(userCreate.UserName));
    }
}
