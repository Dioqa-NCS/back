using API.Modules.Typeentreprises.Ressources;

namespace API.Modules.Typeentreprises.Mapping;

public class TypeentreprisePatchProfile : Profile
{
    public TypeentreprisePatchProfile()
    {
        CreateMap<TypeentreprisePatch, Typeentreprise>()
            .ForAllMembers(opt => opt.ExplicitExpansion());
    }
}
