using DAL.Modules;

namespace DAL.Modules.Tarifs;
public class TarifRepository : Repository<Tarif, int>, ITarifRepository
{
    public TarifRepository(NCSContext Context) : base(Context)
    {
    }
}
