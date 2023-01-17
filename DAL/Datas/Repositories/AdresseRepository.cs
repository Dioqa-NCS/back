namespace DAL.Datas.Repositories;
public class AdresseRepository : Repository<Adresse, int>, IAdresseRepository
{
    public AdresseRepository( NCSContext Context ) : base( Context ) { }
}
