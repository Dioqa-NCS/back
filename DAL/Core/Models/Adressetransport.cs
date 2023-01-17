#nullable disable

namespace DAL.Core.Models;

public partial class Adressetransport : Entity<int>, IModel<int>
{
    public Adressetransport()
    {
        TransportIdAdresseDebutNavigations = new HashSet<Transport>();
        TransportIdAdresseFinNavigations = new HashSet<Transport>();
    }

    public string Nom { get; set; }
    public string MailContact { get; set; }
    public string TelContact { get; set; }
    public string NomContact { get; set; }
    public string Pays { get; set; }
    public string Ville { get; set; }
    public string CodePostal { get; set; }
    public string Adresse { get; set; }
    public string Longitude { get; set; }
    public string Latitude { get; set; }

    public virtual ICollection<Transport> TransportIdAdresseDebutNavigations { get; set; }
    public virtual ICollection<Transport> TransportIdAdresseFinNavigations { get; set; }
}
