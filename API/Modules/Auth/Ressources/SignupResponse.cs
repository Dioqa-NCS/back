namespace API.Modules.Auth.Ressources;

public class SignupResponse
{
    public string UserName { get; set; }

    public SignupResponse(string username)
    {
        this.UserName = username;
    }
}
