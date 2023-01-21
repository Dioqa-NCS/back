using DAL.Modules;

namespace DAL.Modules.Typemoteurs;
public class TypemoteurRepository : Repository<Typemoteur, int>, ITypemoteurRepository
{
    public TypemoteurRepository(NCSContext Context) : base(Context)
    {
    }
}
