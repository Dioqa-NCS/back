using API.Modules.Auth;
using API.Modules.Claims;
using API.Modules.Comptes;
using API.Modules.Comptes.Ressources;
using AutoMapper.AspNet.OData;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers;


[Authorize(Roles = $"{AuthRole.Admin}")]
public class ComptesController : Controller<Compte, CompteResponse, ComptePatch, int>
{

    private readonly UserManager<Compte> _userManager;

    private readonly IClaimService _claimService;

    public ComptesController( 
        ICompteService service, 
        NCSContext context, 
        UserManager<Compte> userManager,
        IClaimService claimService,
        IMapper Mapper) : base( service, context, Mapper )
    { 
        _userManager = userManager;
        _claimService = claimService;
    }

    [HttpGet]
    public override async Task<ActionResult<CompteResponse>> GetAll(
        ODataQueryOptions<CompteResponse> options
        )
    {
        var userName = _claimService.FindSub();

        var user = await _userManager.FindByNameAsync(userName);

        return Ok(await Context.Comptes.Where(compte => compte.Id != user.Id).GetQueryAsync(Mapper, options));
    }
}
