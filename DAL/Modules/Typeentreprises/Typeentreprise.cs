#nullable disable

using DAL.Modules;
using DAL.Modules.Comptes;

namespace DAL.Modules.Typeentreprises;
public partial class Typeentreprise : Entity<int>, IModel<int>
{
    public Typeentreprise()
    {
        Comptes = new HashSet<Compte>();
    }

    public string Nom { get; set; }

    public virtual ICollection<Compte> Comptes { get; set; }
}
