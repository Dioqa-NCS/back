using API.Modules.Comptes;
using API.Modules.Comptes.Ressources;
using DAL;

namespace API.Controllers;


[Authorize(Roles = "Administrateur")]
public class ComptesController : Controller<Compte, CompteResponse, ComptePatch, int>
{
    public ComptesController( 
        ICompteService service, 
        NCSContext context, 
        IMapper Mapper) : base( service, context, Mapper )
    {
    }
}
