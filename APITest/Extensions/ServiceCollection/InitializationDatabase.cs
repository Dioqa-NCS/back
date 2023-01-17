using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Extensions.ServiceCollection;
public static class InitializationDatabase
{
    public static IServiceCollection AddInitializationDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<NCSContext>));

        if(descriptor != null)
        {
            services.Remove(descriptor);
        }

        services.AddDbContext<NCSContext>(options =>
            options.UseMySql(configuration.GetConnectionString("SQL"), new MySqlServerVersion(new Version()))
        );

        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();

        using var appContext = scope.ServiceProvider.GetRequiredService<NCSContext>();
        try
        {
            appContext.Database.EnsureCreated();
        }
        catch(Exception ex)
        {
            throw;
        }
        return services;
    }
}
