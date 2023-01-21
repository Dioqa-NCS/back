#nullable disable

using DAL.Modules;
using DAL.Modules.Comptes;

namespace DAL.Modules.Adresses;

public partial class Adresse : Entity<int>, IModel<int>
{
    public int? IdCompte { get; set; }
    public string Nom { get; set; }
    public string MailContact { get; set; }
    public string TelContact { get; set; }
    public string NomContact { get; set; }
    public string Pays { get; set; }
    public string Ville { get; set; }
    public string CodePostal { get; set; }
    public string Adresse1 { get; set; }
    public string Longitude { get; set; }
    public string Latitude { get; set; }

    public virtual Compte Compte { get; set; }
}
