namespace API.Modules.Auth.Settings;

public class JWTSettings
{
    public string Secret { get; set; }

    public string Issuer { get; set; }

    public string Audience { get; set; }

    public int Expiry { get; set; }

    public int RefreshExpiry { get; set; }
}
