using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Servers.Infrastructure.Persistence;

namespace Modules.Servers.Infrastructure;
public static class ServersInfrastructure
{
    public static IServiceCollection AddServersInfrastructure(
    this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ServersDbContext>(options =>
        {
            options.UseNpgsql(
                config.GetConnectionString("Postgres"),
                npgsql => npgsql.MigrationsHistoryTable("__EFMigrationsHistory", "messages")
            );
        });
        return services;
    }
}
