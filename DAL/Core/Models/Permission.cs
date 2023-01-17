#nullable disable

namespace DAL.Core.Models;
public class Permission : Entity<int>, IModel<int>
{

    public Permission()
    {
        UserCollection = new HashSet<Compte>();
    }

    public string Name { get; set; }

    public ICollection<Compte> UserCollection { get; set; }
}
