namespace DAL.Datas.Repositories;
public class StatuttransportRepository : Repository<Statuttransport, int>, IStatuttransportRepository
{
    public StatuttransportRepository( NCSContext Context ) : base( Context )
    {
    }
}
