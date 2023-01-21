using AutoMapper.AspNet.OData;
using DAL;
using DAL.Modules;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

namespace API.Modules.Shared.Endpoints;

public class AppGetByIdEndpoint
{
    public async Task<SingleResult<TEntityResponse>> GetById<TKey, TEntityResponse, TEntity>(
        [FromServices] NCSContext context,
        [FromServices] IMapper mapper,
        TKey id, 
        ODataQueryOptions<TEntityResponse> options
        )
        where TEntityResponse : class
        where TKey : IEquatable<TKey>
        where TEntity: class, IModel<TKey>
    {
        var query = await context.Set<TEntity>().Where(model => model.Id.Equals(id)).GetQueryAsync(mapper, options);

        return SingleResult.Create(query);
    }
}
