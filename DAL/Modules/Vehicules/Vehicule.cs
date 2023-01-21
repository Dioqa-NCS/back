#nullable disable

using DAL.Modules;
using DAL.Modules.Comptes;
using DAL.Modules.Transports;
using DAL.Modules.Typemoteurs;
using DAL.Modules.Typevehicules;

namespace DAL.Modules.Vehicules;

public partial class Vehicule : Entity<int>, IModel<int>
{
    public Vehicule()
    {
        TransportIdVehiculeLivraisonNavigations = new HashSet<Transport>();
        TransportIdVehiculeRepriseNavigations = new HashSet<Transport>();
    }

    public int IdTypeVehicule { get; set; }
    public int IdTypeMoteur { get; set; }
    public int IdCompte { get; set; }
    public string PlaqueImatriculation { get; set; }
    public string NumeroVin { get; set; }
    public string NomMarque { get; set; }
    public string NomModel { get; set; }
    public string NomCarburant { get; set; }
    public virtual Compte IdCompteNavigation { get; set; }
    public virtual Typemoteur IdTypeMoteurNavigation { get; set; }
    public virtual Typevehicule IdTypeVehiculeNavigation { get; set; }
    public virtual ICollection<Transport> TransportIdVehiculeLivraisonNavigations { get; set; }
    public virtual ICollection<Transport> TransportIdVehiculeRepriseNavigations { get; set; }
}
