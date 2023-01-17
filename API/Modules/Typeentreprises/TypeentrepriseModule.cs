namespace API.Modules.Typeentreprises;

public static class TypeentrepriseModule
{
    public static WebApplicationBuilder RegisterTypeentrepriseModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITypeentrepriseRepository, TypeentrepriseRepository>();
        builder.Services.AddTransient<ITypeentrepriseService, TypeentrepriseService>();

        return builder;
    }
}
