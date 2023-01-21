#nullable disable

using DAL.Modules;
using DAL.Modules.Vehicules;

namespace DAL.Modules.Typemoteurs;

public partial class Typemoteur : Entity<int>, IModel<int>
{
    public Typemoteur()
    {
        Vehicules = new HashSet<Vehicule>();
    }

    public string Nom { get; set; }

    public virtual ICollection<Vehicule> Vehicules { get; set; }
}
