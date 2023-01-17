using API.Modules.Typeentreprises;
using API.Modules.Typeentreprises.Ressources;
using DAL;
using Microsoft.AspNetCore.OData.Query;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TypeentreprisesController : Controller<Typeentreprise, TypeentrepriseResponse, TypeentreprisePatch, int>
{
    public TypeentreprisesController(
        ITypeentrepriseService typeentrepriseService,
        NCSContext context,
        IMapper mapper) : base(typeentrepriseService, context, mapper)
    {
    }


    [HttpGet]
    [AllowAnonymous]
    public override Task<ActionResult<TypeentrepriseResponse>> GetAll(ODataQueryOptions<TypeentrepriseResponse> options)
    {
        return base.GetAll(options);
    }

}