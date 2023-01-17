namespace DAL.Datas.Repositories;
public class MarqueRepository : Repository<Marque, int>, IMarqueRepository
{
    public MarqueRepository( NCSContext Context ) : base( Context )
    {
    }
}
