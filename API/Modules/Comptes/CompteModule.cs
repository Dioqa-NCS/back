using API.Modules.Comptes.Validators;

namespace API.Modules.Comptes;

public static class CompteModule
{
    public static WebApplicationBuilder RegisterCompteModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICompteRepository, CompteRepository>();
        builder.Services.AddTransient<ICompteService, CompteService>();
        builder.Services.AddValidatorsFromAssemblyContaining<ComptePatchValidator>(ServiceLifetime.Transient);

        return builder;
    }
}
