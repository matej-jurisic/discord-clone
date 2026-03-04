using Kernel.CQRS;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.MediatorConfiguration;

public class MediatorConfiguration
{
    public List<Assembly> Assemblies { get; } = [];
}

public static class MediatorExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Action<MediatorConfiguration>? configuration = null)
    {
        var options = new MediatorConfiguration();
        configuration?.Invoke(options);

        services.AddScoped<IMediator, Mediator>();

        var handlerInterfaces = new[]
        {
            typeof(ICommandHandler<>),
            typeof(ICommandHandler<,>),
            typeof(IQueryHandler<,>)
        };

        var handlers = options.Assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => !x.IsAbstract && x.IsClass && !x.IsInterface)
            .SelectMany(x => x.GetInterfaces(), (Type, Interface) => new { Type, Interface })
            .Where(x => x.Interface.IsGenericType && handlerInterfaces.Contains(x.Interface.GetGenericTypeDefinition()));

        foreach (var handler in handlers)
        {
            services.AddScoped(handler.Interface, handler.Type);
        }

        return services;
    }
}
