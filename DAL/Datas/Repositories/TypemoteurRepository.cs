namespace DAL.Datas.Repositories;
public class TypemoteurRepository : Repository<Typemoteur, int>, ITypemoteurRepository
{
    public TypemoteurRepository( NCSContext Context ) : base( Context )
    {
    }
}
