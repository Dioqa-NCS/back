namespace API.Modules.Adresses;

public static class AddesseModule
{
    public static WebApplicationBuilder RegisterAdresseModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAdresseRepository, AdresseRepository>();
        builder.Services.AddTransient<IAdresseService, AdresseService>();

        return builder;
    }
}
