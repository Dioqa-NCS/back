#nullable disable

namespace DAL.Core.Models;

public partial class Statuttransport : Entity<int>, IModel<int>
{
    public Statuttransport()
    {
        Transports = new HashSet<Transport>();
    }

    public string Nom { get; set; }
    public string CouleurHex { get; set; }

    public virtual ICollection<Transport> Transports { get; set; }
}
