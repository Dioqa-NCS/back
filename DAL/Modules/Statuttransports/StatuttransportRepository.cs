using DAL.Modules;

namespace DAL.Modules.Statuttransports;
public class StatuttransportRepository : Repository<Statuttransport, int>, IStatuttransportRepository
{
    public StatuttransportRepository(NCSContext Context) : base(Context)
    {
    }
}
