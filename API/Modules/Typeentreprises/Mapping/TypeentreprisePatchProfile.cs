using API.Controllers;
using API.Modules.Typeentreprises.Ressources;
using DAL.Modules.Typeentreprises;

namespace API.Modules.Typeentreprises.Mapping;

public class TypeentreprisePatchProfile : Profile
{
    public TypeentreprisePatchProfile()
    {
        CreateMap<TypeentreprisePatch, Typeentreprise>()
            .ForAllMembers(opt => opt.ExplicitExpansion());
    }
}
