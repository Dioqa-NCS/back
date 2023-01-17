#nullable disable

namespace DAL.Core.Models;

public partial class Typeentreprise : Entity<int>, IModel<int>
{
    public Typeentreprise()
    {
        Comptes = new HashSet<Compte>();
    }

    public string Nom { get; set; }

    public virtual ICollection<Compte> Comptes { get; set; }
}
