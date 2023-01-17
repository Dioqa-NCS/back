using API.Modules.Comptes.Ressources;
using System.Collections.ObjectModel;

namespace API.Modules.Comptes.Mapping;

public class CompteResponseProfile : Profile
{
    public CompteResponseProfile()
    {
        CreateMap<IEnumerable<Compte>, ObservableCollection<CompteResponse>>();

        CreateMap<Compte, CompteResponse>()
            .ForAllMembers(opt => opt.ExplicitExpansion());
    }
}
