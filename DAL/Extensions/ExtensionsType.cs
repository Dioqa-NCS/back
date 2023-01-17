namespace DAL.Extensions;

public static class ExtensionsType
{
    public static List<PropertyInfo> GetNotNullPropInfos( this Type type, object Object )
    {
        return type
            .GetProperties()
            .Where( ( prop ) => prop.GetValue( Object, null ) != null )
            .ToList();
    }
}
