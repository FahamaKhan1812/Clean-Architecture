using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;

namespace Persistance;
public static class PersistanceServiceExtension
{
    public static void AddPersistanceApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("MSSQLConnector"));
        });

        // register serives
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        
    }
}
