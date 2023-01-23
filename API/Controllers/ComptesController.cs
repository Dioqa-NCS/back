using API.Modules.Auth;
using API.Modules.Comptes;
using API.Modules.Comptes.Ressources;
using AutoMapper.AspNet.OData;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData.Query;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers;


[Authorize(Roles = $"{AuthRole.Admin}")]
public class ComptesController : Controller<Compte, CompteResponse, ComptePatch, int>
{

    private readonly UserManager<Compte> _userManager;

    public ComptesController( 
        ICompteService service, 
        NCSContext context, 
        UserManager<Compte> userManager,
        IMapper Mapper) : base( service, context, Mapper )
    { 
        _userManager = userManager;
    }

    [HttpGet]
    public override async Task<ActionResult<CompteResponse>> GetAll(
        ODataQueryOptions<CompteResponse> options
        )
    {
        var userName = HttpContext.User.Claims.FirstOrDefault(
            claim => claim.Type == JwtRegisteredClaimNames.Sub
            ).Value;

        var user = await _userManager.FindByNameAsync(userName);

        return Ok(await Context.Comptes.Where(compte => compte.Id != user.Id).GetQueryAsync(Mapper, options));
    }
}
