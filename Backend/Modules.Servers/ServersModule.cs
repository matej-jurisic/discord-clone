using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Servers.Api.Controllers;
using Modules.Servers.Infrastructure.Persistence;

namespace Modules.Servers;

public static class ServersModule
{
    public static IServiceCollection AddServersModule(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ServersDbContext>(options =>
            options.UseNpgsql(
                config.GetConnectionString("Postgres"),
                npgsql => npgsql.MigrationsHistoryTable("__EFMigrationsHistory", "servers")
            ));

        services.AddControllers()
            .AddApplicationPart(typeof(ServersController).Assembly);

        return services;
    }
}