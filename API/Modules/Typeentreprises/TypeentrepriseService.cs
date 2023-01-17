using API.Modules.Shared;

namespace API.Modules.Typeentreprises;

public class TypeentrepriseService : Service<Typeentreprise, int>, ITypeentrepriseService
{
    public TypeentrepriseService(ITypeentrepriseRepository TypeentrepriseRepository) : base(TypeentrepriseRepository)
    {
    }
}