using DAL.Modules;
namespace DAL.Modules.Marques;
public class MarqueRepository : Repository<Marque, int>, IMarqueRepository
{
    public MarqueRepository(NCSContext Context) : base(Context)
    {
    }
}
