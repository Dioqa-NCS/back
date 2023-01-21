#nullable disable

using DAL.Modules;

namespace DAL.Modules.Marques;
public partial class Marque : Entity<int>, IModel<int>
{
    public string Nom { get; set; }
}
