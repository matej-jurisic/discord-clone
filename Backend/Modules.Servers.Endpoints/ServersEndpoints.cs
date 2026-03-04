using Microsoft.Extensions.DependencyInjection;

namespace Modules.Servers.Endpoints;

public static class ServersEndpoints
{
    public static IServiceCollection AddServersEndpoints(this IServiceCollection services)
    {
        services.AddMvcCore();

        return services;
    }
}
