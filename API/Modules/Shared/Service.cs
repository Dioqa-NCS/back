using DAL.Extensions;
using DAL.Modules;
using Microsoft.EntityFrameworkCore;
namespace API.Modules.Shared;

public abstract class Service<TEntity, TKey> : IService<TEntity, TKey>
    where TEntity : class, IModel<TKey>
    where TKey : IEquatable<TKey>
{
    public IRepository<TEntity, TKey> Repository { get; set; }

    public Service(IRepository<TEntity, TKey> Repository)
    {
        this.Repository = Repository;
    }


    public async Task<IEnumerable<TEntity>> ReadAsync() => await Repository
    .ReadAsync()
    .ConfigureAwait(false);

    public async Task<TEntity?> ReadAsync(TKey id) => await Repository
        .Where(model => Equals(model.Id, id))
        .FirstOrDefaultAsync()
        .ConfigureAwait(false);

    public async Task<int> WriteAsync()
    {
        try
        {
            return await Repository.WriteAsync().ConfigureAwait(false);
        }
        catch(DbUpdateException ex)
        {
            var innerEx = ex.InnerException;
            throw ex;
        }
    }


    public async Task<TEntity> CreateAsync(TEntity model)
    {
        await this.Repository.AddAsync(model).ConfigureAwait(false);
        return model;
    }
    public async Task<IService<TEntity, TKey>> Update(object id, TEntity modelUpdate)
    {

        var modelToUpdate = await Repository.FindAsync(id).ConfigureAwait(false);

        if (modelToUpdate == null)
        {
            throw new Exception("The entity to be updated does not exist.");
        }

        modelToUpdate.Set(modelUpdate);
        Repository.Update(modelToUpdate);

        return this;
    }

    public async Task DeleteCollection(IEnumerable<TKey> ids)
    {
        var models = await FindAllByIdsAsync(ids);
        this.Repository.RemoveCollection(models);
    }

    public virtual async Task<IEnumerable<TEntity>> UpdateCollectionAsync(IEnumerable<TEntity> modelsPatched)
    {
        var models = await FindAllByIdsAsync(modelsPatched.Select(modelPatched => modelPatched.Id));

        modelsPatched.ToList().ForEach(modelPatched =>
        {
            var model = models.FirstOrDefault(model => Equals(model.Id, modelPatched.Id));

            if(model != null)
            {
                model.Set(modelPatched);
            }
        });

        Repository.UpdateCollection(models);

        await WriteAsync();



        models = await FindAllByIdsAsync(modelsPatched.Select(modelPatched => modelPatched.Id));
        return models;
    }

    protected async Task<IEnumerable<TEntity>> FindAllByIdsAsync(IEnumerable<TKey> ids)
    {
        var models = await Repository
            .Where(model => ids.Contains(model.Id))
            .ReadAsync()
            .ConfigureAwait(false);

        return models;
    }
}
