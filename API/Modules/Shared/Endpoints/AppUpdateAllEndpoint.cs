using DAL.Core.Models;

namespace API.Modules.Shared.Endpoints;

public static class AppUpdateAllEndpoint
{
    public static async Task<IResult> UpdateAll<TEntityPatch, TEntity, TKey>(
        [FromServices] IValidator<TEntityPatch> validator,
        [FromServices] IMapper mapper,
        [FromServices] IService<TEntity, TKey> service,
        [FromBody] IEnumerable<TEntityPatch> modelPatches
        )
        where TKey : IEquatable<TKey>
        where TEntity : class, IModel<TKey>
    {

        foreach(var modelPatch in modelPatches)
        {
            var validationResult = await validator.ValidateAsync(modelPatch);
            if(!validationResult.IsValid)
            {
                return Results.BadRequest(new ErrorMessage(message: "Les paramétres renseignés sont incorrects.", errorMessages: validationResult.Errors).GetError());
            }
        }

        var models = mapper.Map<IEnumerable<TEntityPatch>, IEnumerable<TEntity>>(modelPatches);

        models = await service.UpdateCollectionAsync(models);

        modelPatches = mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityPatch>>(models);

        return Results.Ok(modelPatches);
    }
}
