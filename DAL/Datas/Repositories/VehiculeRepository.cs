namespace DAL.Datas.Repositories;
public class VehiculeRepository : Repository<Vehicule, int>, IVehiculeRepository
{
    public VehiculeRepository( NCSContext Context ) : base( Context )
    {
    }
}
