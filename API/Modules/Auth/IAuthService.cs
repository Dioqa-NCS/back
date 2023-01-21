using API.Modules.Auth.Ressources;
using DAL.Modules.Comptes;

namespace API.Modules.Auth;

public interface IAuthService
{
    Task<SigninRessponse?> SignInAsync(Compte user);

    Task<Compte?> SignupAsync(Compte user);

    Task SignoutAsync();
}
