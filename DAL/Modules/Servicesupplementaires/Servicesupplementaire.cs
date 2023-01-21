#nullable disable

using DAL.Modules;

namespace DAL.Modules.Servicesupplementaires;

public partial class Servicesupplementaire : Entity<int>, IModel<int>
{
    public string Nom { get; set; }
    public decimal? Prix { get; set; }
}
