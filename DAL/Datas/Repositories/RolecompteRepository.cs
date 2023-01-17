namespace DAL.Datas.Repositories;
public class RolecompteRepository : Repository<Rolecompte, int>, IRolecompteRepository
{
    public RolecompteRepository( NCSContext Context ) : base( Context )
    {
    }
}
