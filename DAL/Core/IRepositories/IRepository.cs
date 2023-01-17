using System.Linq.Expressions;

namespace DAL.Core.IRepositories.IRepository;

public interface IRepository<TEntity, TKey>
    where TEntity : class, IModel<TKey>
    where TKey : IEquatable<TKey>
{
    Task<TEntity?> FirstOrDefaultAsync();

    ValueTask<TEntity?> FindAsync( object prop );

    IRepository<TEntity, TKey> Where( Expression<Func<TEntity, bool>> predicate );

    Task<IEnumerable<TEntity>> ReadAsync();

    void Remove( TEntity model );

    void RemoveCollection( IEnumerable<TEntity> collectionModel );

    Task<int> WriteAsync();

    Task AddAsync( TEntity model );

    Task AddCollectionAsync( IEnumerable<TEntity> collectionModel );

    void Update( TEntity model );

    void UpdateCollection( IEnumerable<TEntity> collectionModel );
}
