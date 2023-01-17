using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Datas.Repositories;

public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IModel<TKey>
    where TKey: IEquatable<TKey>
{

    protected readonly NCSContext Context;

    public IQueryable<TEntity> Query { get; set; }

    public Repository( NCSContext Context )
    {
        this.Context = Context;
        this.Query = this.Context.Set<TEntity>().AsQueryable();
    }

    public async Task<TEntity?> FirstOrDefaultAsync() => await this.Query
        .FirstOrDefaultAsync()
        .ConfigureAwait( false );


    public async ValueTask<TEntity?> FindAsync( object prop ) => await this.Context.Set<TEntity>()
            .FindAsync( prop )
            .ConfigureAwait( false );

    public async Task<IEnumerable<TEntity>> ReadAsync() => await this.Query
        .ToListAsync()
        .ConfigureAwait( false );


    public IRepository<TEntity, TKey> Where( Expression<Func<TEntity, bool>> predicate )
    {
        this.Query = this.Query.Where( predicate );
        return this;
    }

    public void Remove( TEntity model )
    {
        this.Context.Set<TEntity>().Remove( model );
    }

    public void RemoveCollection( IEnumerable<TEntity> collectionModel )
    {
        Context.Set<TEntity>().RemoveRange( collectionModel );
    }

    public async Task<int> WriteAsync() => await this.Context.SaveChangesAsync().ConfigureAwait( false );


    public async Task AddAsync( TEntity model )
    {
        await this.Context.Set<TEntity>().AddAsync( model ).ConfigureAwait( false );
    }

    public async Task AddCollectionAsync( IEnumerable<TEntity> collectionModel )
    {
        await this.Context.Set<TEntity>().AddRangeAsync( collectionModel ).ConfigureAwait( false );
    }

    public void Update( TEntity model )
    {
        this.Context.Set<TEntity>().Update( model );
    }

    public void UpdateCollection( IEnumerable<TEntity> collectionModel )
    {
        this.Context.Set<TEntity>().UpdateRange( collectionModel );
    }
}
