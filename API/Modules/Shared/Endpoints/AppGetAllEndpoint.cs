using AutoMapper.AspNet.OData;
using DAL;
using DAL.Modules;
using Microsoft.AspNetCore.OData.Query;

namespace API.Modules.Shared.Endpoints;

public static class AppGetAllEndpoint
{
    public static async Task<IResult> GetAll<TEntity, TEntityResponse, TEntityPatch, TKey>(
        NCSContext context,
        IMapper mapper,
        ODataQueryOptions<TEntityResponse> options
        ) where TEntityResponse : class
          where TEntity : class, IModel<TKey>
          where TKey : IEquatable<TKey>
    {
        return Results.Ok(await context.Set<TEntity>().GetQueryAsync(mapper, options));
    }
}
