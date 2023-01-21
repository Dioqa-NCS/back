using DAL.Modules;

namespace DAL.Modules.Typeentreprises;
public class TypeentrepriseRepository : Repository<Typeentreprise, int>, ITypeentrepriseRepository
{
    public TypeentrepriseRepository(NCSContext Context) : base(Context)
    {
    }
}
