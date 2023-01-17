using API.Modules.Adresses.Ressources;

namespace API.Modules.Adresses.Mapping;

public class AdressePatchProfile : Profile
{
    public AdressePatchProfile()
    {
        CreateMap<AdressePatch, Adresse>()
            .ForAllMembers(opt => opt.ExplicitExpansion());
    }
}
