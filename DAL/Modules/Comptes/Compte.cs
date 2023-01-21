#nullable disable

using DAL.Modules;
using DAL.Modules.Adresses;
using DAL.Modules.Rolecomptes;
using DAL.Modules.Transports;
using DAL.Modules.Typeentreprises;
using DAL.Modules.Vehicules;
using Microsoft.AspNetCore.Identity;

namespace DAL.Modules.Comptes;

public partial class Compte : IdentityUser<int>, IModel<int>
{
    public Compte()
    {
        Adresses = new HashSet<Adresse>();
        Transports = new HashSet<Transport>();
        Vehicules = new HashSet<Vehicule>();
    }

    public int IdRoleCompte { get; set; }
    public int IdTypeEntreprise { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Mail { get; set; }
    public string Tel { get; set; }
    public string Mdp { get; set; }
    public string NomEntreprise { get; set; }
    public string RefreshToken { get; set; }
    public string AdresseFacturation { get; set; }
    public string VilleFacturation { get; set; }
    public string CodePostalFacturation { get; set; }
    public string TelFacturation { get; set; }
    public string MailFacturation { get; set; }
    public int? ReductionPrix { get; set; }
    public string EstValider { get; set; }
    public virtual Rolecompte IdRoleCompteNavigation { get; set; }
    public virtual Typeentreprise TypeEntreprise { get; set; }
    public virtual ICollection<Adresse> Adresses { get; set; }
    public virtual ICollection<Transport> Transports { get; set; }
    public virtual ICollection<Vehicule> Vehicules { get; set; }
    public virtual ICollection<IdentityRole> Roles { get; set; }
}
