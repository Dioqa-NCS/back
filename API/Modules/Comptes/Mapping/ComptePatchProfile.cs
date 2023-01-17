using API.Modules.Comptes.Ressources;
using System.Collections.ObjectModel;

namespace API.Modules.Comptes.Mapping;

public class ComptePatchProfile : Profile
{
    public ComptePatchProfile()
    {
        CreateMap<IEnumerable<ComptePatch>, ObservableCollection<Compte>>()
            .ReverseMap();

        CreateMap<ComptePatch, Compte>()
            .ForMember(opt => opt.IdRoleCompte, opt =>
            {
                opt.PreCondition(src => src.IdRoleCompte == null);
                opt.MapFrom(src => src.IdRoleCompte);
            })
            .ForAllMembers(opt => opt.AllowNull());

        CreateMap<Compte, ComptePatch>()
            .ForAllMembers(opt => opt.AllowNull());
    }
}
