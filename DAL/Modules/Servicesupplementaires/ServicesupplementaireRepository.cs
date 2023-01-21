using DAL.Modules;

namespace DAL.Modules.Servicesupplementaires;
public class ServicesupplementaireRepository : Repository<Servicesupplementaire, int>, IServicesupplementaireRepository
{
    public ServicesupplementaireRepository(NCSContext Context) : base(Context)
    {
    }
}
