using System.Data.SqlTypes;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("medeixeApiDb"));
        }
        else
        {
            var conStrBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));
            conStrBuilder.Password = configuration["DbPassword"];
            string connectionString = conStrBuilder.ConnectionString;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}