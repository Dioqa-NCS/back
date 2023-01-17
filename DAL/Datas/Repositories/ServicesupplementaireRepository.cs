namespace DAL.Datas.Repositories;
public class ServicesupplementaireRepository : Repository<Servicesupplementaire, int>, IServicesupplementaireRepository
{
    public ServicesupplementaireRepository( NCSContext Context ) : base( Context )
    {
    }
}
