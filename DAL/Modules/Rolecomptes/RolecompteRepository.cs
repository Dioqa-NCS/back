using DAL.Modules;

namespace DAL.Modules.Rolecomptes;
public class RolecompteRepository : Repository<Rolecompte, int>, IRolecompteRepository
{
    public RolecompteRepository(NCSContext Context) : base(Context)
    {
    }
}
