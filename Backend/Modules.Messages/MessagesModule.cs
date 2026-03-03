using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Messages.Api.Controllers;
using Modules.Messages.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Messages;

public static class MessagesModule
{
    public static IServiceCollection AddMessagesModule(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<MessagesDbContext>(options =>
        {
            options.UseNpgsql(
                config.GetConnectionString("Postgres"),
                npgsql => npgsql.MigrationsHistoryTable("__EFMigrationsHistory", "messages")
            );
        });

        services.AddControllers().AddApplicationPart(typeof(MessagesController).Assembly);

        return services;
    }
}
