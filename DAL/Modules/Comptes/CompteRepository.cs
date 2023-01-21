using DAL.Modules;
namespace DAL.Modules.Comptes;
public class CompteRepository : Repository<Compte, int>, ICompteRepository
{
    public CompteRepository(NCSContext Context) : base(Context)
    {
    }
}
