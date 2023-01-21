#nullable enable

namespace API.Modules.Auth.Ressources;

public class SigninRessponse
{
    public SigninRessponse(ICollection<string> roles)
    {
        Roles = roles;
    }

    public ICollection<string> Roles { get; set; }
}
