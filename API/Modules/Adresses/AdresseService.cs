using API.Modules.Shared;

namespace API.Modules.Adresses;

public class AdresseService : Service<Adresse, int>, IAdresseService
{
    public AdresseService(IAdresseRepository repository) : base(repository)
    {
    }
}
