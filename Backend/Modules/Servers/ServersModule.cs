using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Servers
{
    public static class ServersModule
    {
        public static IServiceCollection AddServersModule(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
