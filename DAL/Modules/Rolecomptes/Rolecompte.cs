#nullable disable

using DAL.Modules;
using DAL.Modules.Comptes;

namespace DAL.Modules.Rolecomptes;
public partial class Rolecompte : Entity<int>, IModel<int>
{
    public Rolecompte()
    {
        Comptes = new HashSet<Compte>();
    }

    public string Nom { get; set; }

    public virtual ICollection<Compte> Comptes { get; set; }
}
