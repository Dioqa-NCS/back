using API.Modules.Typeentreprises.Ressources;

namespace API.Modules.Typeentreprises.Mapping;

public class TypeentrepriseResponseProfile : Profile
{
    public TypeentrepriseResponseProfile()
    {
        CreateMap<Typeentreprise, TypeentrepriseResponse>()
            .ForAllMembers(opt => opt.ExplicitExpansion());
    }
}
