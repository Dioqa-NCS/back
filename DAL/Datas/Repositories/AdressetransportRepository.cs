namespace DAL.Datas.Repositories;

public class AdressetransportRepository : Repository<Adressetransport, int>, IAdressetransportRepository
{
    public AdressetransportRepository( NCSContext Context ) : base( Context )
    {
    }
}
