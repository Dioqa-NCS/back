#nullable disable

namespace DAL.Core.Models;

public partial class Tarif : Entity<int>, IModel<int>
{
    public int IntervalKmMin { get; set; }
    public int IntervalKmMax { get; set; }
    public decimal? PrixAllerSimple { get; set; }
    public decimal? PrixAllerRetour { get; set; }
}
