using API.Modules.Auth;
using API.Modules.Claims;
using API.Modules.Comptes.Ressources;
using AutoMapper.AspNet.OData;
using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers;


[EnableCors("OpenCORSPolicy")]
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = $"{AuthRole.Admin}")]
public class SettingsController : ODataController
{

    public readonly IMapper Mapper;

    public readonly NCSContext Context;

    private readonly IClaimService _claimService;

    public SettingsController(
        IMapper mapper,
        NCSContext context,
        IClaimService claimService
        )
	{
		Mapper = mapper;
        Context = context;
        _claimService = claimService;
	}

    [HttpGet("Compte")]
    [Authorize(Roles = $"{AuthRole.Admin}, {AuthRole.Customer}")]
    public async Task<SingleResult<CompteResponse>> MyCompte(
        [FromServices] UserManager<Compte> userManager,
        ODataQueryOptions<CompteResponse> options
        )
    {
        var userName = _claimService.FindSub();
        
        var user = await userManager.FindByNameAsync(userName);
        
        var query = await Context.Comptes.Where(model => model.Id == user.Id).GetQueryAsync(Mapper, options);

        return SingleResult.Create(query);
    }

}
