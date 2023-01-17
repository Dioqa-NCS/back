namespace DAL.Datas.Repositories;
public class TransportRepository : Repository<Transport, int>, ITransportRepository
{
    public TransportRepository( NCSContext Context ) : base( Context )
    {
    }
}
