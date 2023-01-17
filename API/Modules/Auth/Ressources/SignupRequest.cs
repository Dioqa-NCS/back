namespace API.Modules.Auth.Ressources;

public class SignupRequest
{
    public string UserName { get; set; }
    public int IdTypeEntreprise { get; set; }
    public string Email { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Mail { get; set; }
    public string Tel { get; set; }
    public string Mdp { get; set; }
    public string MdpConfirmation { get; set; }
    public string NomEntreprise { get; set; }
    public string AdresseFacturation { get; set; }
    public string VilleFacturation { get; set; }
    public string CodePostalFacturation { get; set; }
    public string? TelFacturation { get; set; }
    public string? MailFacturation { get; set; }
}
