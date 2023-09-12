using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;
public static class ServiceExtenstions
{
    public static void AddApplication(this IServiceCollection services) 
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
