using API.Modules.Shared.QueryParams;
using API.Modules.Shared.Validators;

namespace API.Modules.Shared;

public static class SharedModule
{
    public static WebApplicationBuilder  RegisterSharedeModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IValidator<QueryParamsIds<int>>, QueryParamsIdsValidator<int>>();
        builder.Services.AddTransient<IMailService, MailService>();

        return builder;
    }
}
