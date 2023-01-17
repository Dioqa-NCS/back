using API.Modules.Shared;

namespace API.Modules.Comptes;

public class CompteService : Service<Compte, int>, ICompteService
{
    public CompteService(ICompteRepository Repository) : base(Repository)
    {

    }
}
