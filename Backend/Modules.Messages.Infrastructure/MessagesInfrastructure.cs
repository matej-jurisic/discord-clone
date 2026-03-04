using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Messages.Application.Common.Interfaces;
using Modules.Messages.Infrastructure.Persistence;

namespace Modules.Messages.Infrastructure;

public static class MessagesInfrastructure
{
    public static IServiceCollection AddMessagesInfrastructure(
    this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<MessagesDbContext>(options =>
        {
            options.UseNpgsql(
                config.GetConnectionString("Postgres"),
                npgsql => npgsql.MigrationsHistoryTable("__EFMigrationsHistory", "messages")
            );
        });

        services.AddScoped<IMessagesDbContext>(provider => provider.GetRequiredService<MessagesDbContext>());

        return services;
    }
}
