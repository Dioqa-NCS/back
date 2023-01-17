namespace DAL.Extensions;
public static class Model
{
    public static void Set<TKey>( this IModel<TKey> entityToSet, IModel<TKey> entity ) where TKey : IEquatable<TKey>
    {
        entity
           .GetType()
           .GetNotNullPropInfos( entity )
           .ForEach( propInfo =>
           {
               entityToSet
                  .GetType()
                  .GetProperty( propInfo.Name )
                  .SetValue( entityToSet, propInfo.GetValue( entity ) );
           } );
    }
}
