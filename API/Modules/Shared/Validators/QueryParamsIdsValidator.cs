using API.Modules.Shared.QueryParams;

namespace API.Modules.Shared.Validators;

public class QueryParamsIdsValidator<TKey> : AbstractValidator<QueryParamsIds<TKey>>
    where TKey : IEquatable<TKey>
{
    public QueryParamsIdsValidator()
    {
        if(typeof(TKey) == typeof(int))
        {
            RuleFor(queryParamIds => queryParamIds.Ids)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d+(,\s*\d+)*$")
                .WithMessage("Le paramètre Ids doit être défini avec le format '1, 2, 3, ... 1000'");
        }
    }
}
