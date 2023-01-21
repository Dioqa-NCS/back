#nullable disable

using DAL.Modules;

namespace DAL.Modules.Tickets;

public partial class Ticket : Entity<int>, IModel<int>
{
    public string NomEntreprise { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Telephone { get; set; }
    public string Sujet { get; set; }
    public string Mail { get; set; }
    public DateTime DateHeureEnvoie { get; set; }
    public string Message { get; set; }
}
