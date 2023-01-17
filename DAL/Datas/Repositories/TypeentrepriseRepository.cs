namespace DAL.Datas.Repositories;
public class TypeentrepriseRepository : Repository<Typeentreprise, int>, ITypeentrepriseRepository
{
    public TypeentrepriseRepository( NCSContext Context ) : base( Context )
    {
    }
}
