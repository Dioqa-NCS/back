#nullable disable

namespace DAL.Core.Models;

public partial class Marque : Entity<int>, IModel<int>
{
    public string Nom { get; set; }
}
