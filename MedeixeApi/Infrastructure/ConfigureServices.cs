using System.Data.SqlTypes;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseLocalServer"))
        {
            string connectionString = configuration.GetConnectionString("LocalConnection");
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(
                    connectionString,
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName).EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null)
                )
            ); 
        }
        else
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") + $";Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(
                    connectionString, 
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}