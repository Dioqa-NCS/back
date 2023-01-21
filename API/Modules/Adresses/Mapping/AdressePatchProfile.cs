using API.Modules.Adresses.Ressources;
using DAL.Modules.Adresses;

namespace API.Modules.Adresses.Mapping;

public class AdressePatchProfile : Profile
{
    public AdressePatchProfile()
    {
        CreateMap<AdressePatch, Adresse>()
            .ForAllMembers(opt => opt.ExplicitExpansion());
    }
}
