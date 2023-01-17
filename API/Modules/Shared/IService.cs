using DAL.Core.Models;

namespace API.Modules.Shared;

public interface IService<TEntity, TKey>
    where TEntity : class, IModel<TKey>
    where TKey : IEquatable<TKey>
{
    Task<IEnumerable<TEntity>> ReadAsync();

    Task<TEntity?> ReadAsync(TKey id);

    Task<int> WriteAsync();
    Task<TEntity> CreateAsync(TEntity model);
    Task<IService<TEntity, TKey>> Update(object id, TEntity model);

    Task DeleteCollection(IEnumerable<TKey> Ids);

    Task<IEnumerable<TEntity>> UpdateCollectionAsync(IEnumerable<TEntity> modelsPatched);
}
