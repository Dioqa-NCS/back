using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Modules.Shared.QueryParams;

public class QueryParamsIds<TKey> where TKey : IEquatable<TKey>
{
    public static Type typeIds = typeof(TKey);

    [BindRequired]
    public string Ids { get; set; }


    public List<TKey> CastListIds()
    {
        var idsConverToInt = string.Join("", this.Ids)
            .Trim()
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(id => (TKey)Convert.ChangeType(id, typeof(TKey)))
            .ToList();

        return idsConverToInt;
    }
}
