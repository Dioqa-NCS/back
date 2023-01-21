using DAL.Modules;

namespace DAL.Modules.Typevehicules;
public class TypevehiculeRepository : Repository<Typevehicule, int>, ITypevehiculeRepository
{
    public TypevehiculeRepository(NCSContext Context) : base(Context)
    {
    }
}
