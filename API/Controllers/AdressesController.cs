using API.Modules.Adresses;
using API.Modules.Adresses.Ressources;
using API.Modules.Auth;
using DAL;

namespace API.Controllers;

[Route( "api/[controller]" )]
[ApiController]
[Authorize(Roles = "Administrateur, Client")]
public class AdressesController : Controller<Adresse, AdressseResponse, AdressePatch, int>
{
    public AdressesController( 
        IAdresseService adresseService, 
        NCSContext context, 
        IMapper Mapper) : 
        base( adresseService, context, Mapper )
    {
    }
}
