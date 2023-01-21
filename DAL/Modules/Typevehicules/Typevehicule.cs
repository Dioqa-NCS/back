#nullable disable

using DAL.Modules;
using DAL.Modules.Vehicules;

namespace DAL.Modules.Typevehicules;

public partial class Typevehicule : Entity<int>, IModel<int>
{
    public Typevehicule()
    {
        Vehicules = new HashSet<Vehicule>();
    }

    public string Nom { get; set; }
    public string Description { get; set; }
    public int Coefficiant { get; set; }

    public virtual ICollection<Vehicule> Vehicules { get; set; }
}
