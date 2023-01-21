using DAL.Modules;

namespace DAL.Modules.Adressetransports;

public class AdressetransportRepository : Repository<Adressetransport, int>, IAdressetransportRepository
{
    public AdressetransportRepository(NCSContext Context) : base(Context)
    {
    }
}
