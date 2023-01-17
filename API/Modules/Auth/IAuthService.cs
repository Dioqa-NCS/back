using API.Modules.Auth.Ressources;

namespace API.Modules.Auth;

public interface IAuthService
{
    Task<SigninRessponse?> SignInAsync(Compte user);

    Task<Compte?> SignupAsync(Compte user);

    Task SignoutAsync();
}
