using DAL.Modules;

namespace DAL.Modules.Transports;
public class TransportRepository : Repository<Transport, int>, ITransportRepository
{
    public TransportRepository(NCSContext Context) : base(Context)
    {
    }
}
