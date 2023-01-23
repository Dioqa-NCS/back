#nullable enable

namespace API.Modules.Auth.Ressources;

public struct SigninRessponse
{
    public IEnumerable<string> Roles { get; set; }
}
