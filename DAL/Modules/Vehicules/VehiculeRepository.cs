using DAL.Modules;

namespace DAL.Modules.Vehicules;
public class VehiculeRepository : Repository<Vehicule, int>, IVehiculeRepository
{
    public VehiculeRepository(NCSContext Context) : base(Context)
    {
    }
}
