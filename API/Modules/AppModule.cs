﻿using API.Modules.Adresses;
using API.Modules.Auth;
using API.Modules.Claims;
using API.Modules.Comptes;
using API.Modules.Shared;
using API.Modules.Swagger;
using API.Modules.Typeentreprises;
using DAL;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace API.Modules;

public static class AppModule
{
    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault)
            .AddOData( options =>
            {
                options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null);
            });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddProblemDetails();

        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");

        builder.Services.AddDbContext<NCSContext>(options =>
            options.UseMySql(
                Environment.GetEnvironmentVariable("DATABASE_CONNECTION"), 
                new MySqlServerVersion(new Version()), 
                x => x.MigrationsAssembly("DAL")
                )
            );


        builder.RegisterSwaggerModule();

        builder.RegisterAuthModule();

        builder.RegisterAdresseModule();

        builder.RegisterCompteModule();

        builder.RegisterSharedeModule();
        
        builder.RegisterTypeentrepriseModule();

        builder.RegisterClaimModule();

        return builder;
    }

    public static WebApplication RegisterHttpPipeline(this WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler();
            
            app.UseHsts();
            // app.UseExceptionHandler("/error-development");
        }

        if(app.Environment.IsProduction())
        {
            // app.UseExceptionHandler("/error");
        }

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(AuthPolicies.CORS);

        app.UseAuthentication();

        app.UseAuthorization();


        return app;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {

        app.MapAuthEndpoints();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.MapControllers();

        return app;
    }
}
