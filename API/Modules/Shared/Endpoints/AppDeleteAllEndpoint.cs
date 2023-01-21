using API.Modules.Shared.QueryParams;
using DAL.Modules;

namespace API.Modules.Shared.Endpoints;

public static class AppDeleteAllEndpoint
{
    public static async Task<IResult> DeleteAll<TKey, TEntity>(
        [FromServices] IService<TEntity, TKey> service,
        [FromServices] IValidator<QueryParamsIds<TKey>> validator,
        [FromQuery] QueryParamsIds<TKey> queryParamsIds
        )
        where TKey : IEquatable<TKey>
        where TEntity : class, IModel<TKey>
    {


        var validationResult = await validator.ValidateAsync(queryParamsIds);

        if(!validationResult.IsValid)
        {
            return Results.BadRequest(new ErrorMessage(message: "Les paramétres renseignés sont incorrects.", errorMessages: validationResult.Errors).GetError());
        }

        var ids = queryParamsIds.CastListIds();

        await service.DeleteCollection(ids);

        await service.WriteAsync();

        return Results.NoContent();
    }
}
