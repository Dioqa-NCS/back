using API.Modules.Auth;
using API.Modules.Comptes;
using API.Modules.Comptes.Ressources;
using DAL;
using DAL.Modules.Comptes;

namespace API.Controllers;


[Authorize(Roles = $"{AuthRole.Admin}")]
public class ComptesController : Controller<Compte, CompteResponse, ComptePatch, int>
{
    public ComptesController( 
        ICompteService service, 
        NCSContext context, 
        IMapper Mapper) : base( service, context, Mapper )
    {
    }
}
