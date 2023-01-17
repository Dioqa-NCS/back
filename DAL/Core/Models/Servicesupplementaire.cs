#nullable disable

namespace DAL.Core.Models;

public partial class Servicesupplementaire : Entity<int>, IModel<int>
{
    public string Nom { get; set; }
    public decimal? Prix { get; set; }
}
