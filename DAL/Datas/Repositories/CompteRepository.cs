namespace DAL.Datas.Repositories;
public class CompteRepository : Repository<Compte, int>, ICompteRepository
{
    public CompteRepository( NCSContext Context ) : base( Context )
    {
    }
}
