namespace API.Modules.Claims;

public static class ClaimsModule
{
    public static WebApplicationBuilder RegisterClaimModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IClaimService, ClaimService>();

        return builder;
    }
}
