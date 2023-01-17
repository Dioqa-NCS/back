#nullable disable

namespace DAL.Core.Models;

public partial class Transport : Entity<int>, IModel<int>
{
    public Transport()
    {
        Servicesupplementairetransports = new HashSet<Servicesupplementairetransport>();
    }

    public int IdCompte { get; set; }
    public int? IdVehiculeLivraison { get; set; }
    public int? IdVehiculeReprise { get; set; }
    public string TypeTransport { get; set; }
    public int? IdStatutTransport { get; set; }
    public int IdAdresseDebut { get; set; }
    public int IdAdresseFin { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    public string Commentaire { get; set; }
    public decimal DistanceKm { get; set; }
    public decimal PrixTotal { get; set; }
    public string Reference { get; set; }
    public string BonCommande { get; set; }

    public virtual Adressetransport IdAdresseDebutNavigation { get; set; }
    public virtual Adressetransport IdAdresseFinNavigation { get; set; }
    public virtual Compte IdCompteNavigation { get; set; }
    public virtual Statuttransport IdStatutTransportNavigation { get; set; }
    public virtual Vehicule IdVehiculeLivraisonNavigation { get; set; }
    public virtual Vehicule IdVehiculeRepriseNavigation { get; set; }
    public virtual ICollection<Servicesupplementairetransport> Servicesupplementairetransports { get; set; }
}
