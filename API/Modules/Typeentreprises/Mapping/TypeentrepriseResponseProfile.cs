using API.Controllers;
using API.Modules.Typeentreprises.Ressources;
using DAL.Modules.Typeentreprises;

namespace API.Modules.Typeentreprises.Mapping;

public class TypeentrepriseResponseProfile : Profile
{
    public TypeentrepriseResponseProfile()
    {
        CreateMap<Typeentreprise, TypeentrepriseResponse>()
            .ForAllMembers(opt => opt.ExplicitExpansion());
    }
}
