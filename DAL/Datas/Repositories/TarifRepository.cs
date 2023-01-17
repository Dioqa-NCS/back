namespace DAL.Datas.Repositories;
public class TarifRepository : Repository<Tarif, int>, ITarifRepository
{
    public TarifRepository( NCSContext Context ) : base( Context )
    {
    }
}
