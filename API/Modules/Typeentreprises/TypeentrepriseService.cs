using API.Modules.Shared;
using DAL.Modules.Typeentreprises;

namespace API.Modules.Typeentreprises;

public class TypeentrepriseService : Service<Typeentreprise, int>, ITypeentrepriseService
{
    public TypeentrepriseService(ITypeentrepriseRepository TypeentrepriseRepository) : base(TypeentrepriseRepository)
    {
    }
}