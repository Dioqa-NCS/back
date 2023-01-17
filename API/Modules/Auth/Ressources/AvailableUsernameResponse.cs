namespace API.Modules.Auth.Ressources;

public class AvailableUsernameResponse
{
    public bool Available { get; set; }

    public AvailableUsernameResponse(bool available)
    {
        this.Available = available;
    }
}
