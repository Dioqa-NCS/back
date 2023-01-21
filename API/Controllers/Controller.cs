using API.Modules.Shared;
using API.Modules.Shared.QueryParams;
using AutoMapper.AspNet.OData;
using DAL;
using DAL.Modules;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers;

[EnableCors( "OpenCORSPolicy" )]
[Route( "api/[controller]" )]
[ApiController]
public abstract class Controller<TEntity, TEntityResponse, TEntityPatch, TKey> : ODataController
    where TEntity : class, IModel<TKey>
    where TEntityResponse : class
    where TKey : IEquatable<TKey>
    where TEntityPatch: class
{

    private readonly IService<TEntity, TKey> _service;

    private readonly NCSContext _context;

    private readonly IMapper _mapper;

    public Controller( 
        IService<TEntity, TKey> service, 
        NCSContext context, 
        IMapper mapper
        )
    {
        _service = service;
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public virtual async Task<ActionResult<TEntityResponse>> GetAll( ODataQueryOptions<TEntityResponse> options )
    {
        return Ok(await _context.Set<TEntity>().GetQueryAsync( _mapper, options ) );
    }


    [HttpGet( "{id}" )]
    public async Task<SingleResult<TEntityResponse>> GetById(TKey id, ODataQueryOptions<TEntityResponse> options )
    {
        var query = await _context.Set<TEntity>().Where( model => model.Id.Equals( id ) ).GetQueryAsync( _mapper, options );

        return SingleResult.Create( query );
    }

    [HttpPost]
    public async Task<IActionResult> CreateModelAsync([FromBody] TEntity model)
    {
        var modelCreate = await _service.CreateAsync( model );
        await _service.WriteAsync();
        return Created( modelCreate );
    }


    [HttpPatch]
    public async Task<ActionResult<IEnumerable<TEntityPatch>>> UpdateAllAsync( 
        [FromServices] IValidator<TEntityPatch> validator,
        [FromBody] IEnumerable<TEntityPatch> modelPatches
        )
    {

        foreach(var modelPatch in modelPatches)
        {
            var validationResult = await validator.ValidateAsync( modelPatch );
            if (!validationResult.IsValid)
            {
                return BadRequest( new ErrorMessage( message: "Les paramétres renseignés sont incorrects.", errorMessages: validationResult.Errors ).GetError() );
            }
        }

        var models = _mapper.Map<IEnumerable<TEntityPatch>, IEnumerable<TEntity>>( modelPatches );

        models = await _service.UpdateCollectionAsync( models );

        modelPatches = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityPatch>>(models );

        return Ok( modelPatches );
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAllAsync( 
        [FromServices] IValidator<QueryParamsIds<TKey>> validator,
        [FromQuery] QueryParamsIds<TKey> queryParamsIds
        )
    {


        var validationResult = await validator.ValidateAsync( queryParamsIds );

        if (!validationResult.IsValid)
        {
            return BadRequest( new ErrorMessage( message: "Les paramétres renseignés sont incorrects.", errorMessages: validationResult.Errors ).GetError() );
        }

        var ids = queryParamsIds.CastListIds();

        await _service.DeleteCollection( ids );

        await _service.WriteAsync();

        return NoContent();
    }

}
