namespace API.Modules.Auth.Ressources;

public class SignedinResponse
{
    public string? Username { get; set; }

    public bool Authenticated { get; set; }

    public List<string>? Roles { get; set; }

    public SignedinResponse(string username, bool authentificated, List<string>? roles)
    {
        this.Username = username;
        this.Authenticated = authentificated;
        this.Roles = roles;
    }
}
