using DAL.Modules;

namespace API.Modules.Shared.Endpoints;

public static class AppCreateModelEndpoint
{
    public static async Task<IResult> CreateModel<TEntity, TKey>(
        [FromServices] IService<TEntity, TKey> service,
        [FromBody] TEntity model
        )
        where TEntity : class, IModel<TKey>
        where TKey : IEquatable<TKey>
    {
        var modelCreate = await service.CreateAsync(model);
        await service.WriteAsync();
        return Results.Created("uri", modelCreate);
    }
}
