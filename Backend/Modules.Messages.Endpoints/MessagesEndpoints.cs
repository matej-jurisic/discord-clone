using Microsoft.Extensions.DependencyInjection;
using Modules.Messages.Endpoints.Controllers;

namespace Modules.Messages.Endpoints;

public static class MessagesEndpoints
{
    public static IServiceCollection AddMessagesEndpoints(
    this IServiceCollection services)
    {
        services.AddMvcCore()
                .AddApplicationPart(typeof(MessagesController).Assembly);

        return services;
    }
}
