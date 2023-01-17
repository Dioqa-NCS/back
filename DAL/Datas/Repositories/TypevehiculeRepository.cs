namespace DAL.Datas.Repositories;
public class TypevehiculeRepository : Repository<Typevehicule, int>, ITypevehiculeRepository
{
    public TypevehiculeRepository( NCSContext Context ) : base( Context )
    {
    }
}
