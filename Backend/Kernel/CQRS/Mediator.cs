using Kernel.Results;
using System.Collections.Concurrent;

namespace Kernel.CQRS;

public sealed partial class Mediator(IServiceProvider _serviceProvider) : IMediator
{
    private static readonly ConcurrentDictionary<Type, object> _cache = new();

    public Task<Result> SendAsync(
        ICommand command,
        CancellationToken cancellationToken = default)
    {
        if (command is null)
            throw new ArgumentNullException(nameof(command));

        var handler = (CommandHandlerWrapper)_cache.GetOrAdd(command.GetType(), static x =>
        {
            var wrapperType = typeof(CommandHandlerWrapperImplementation<>).MakeGenericType(x);
            return Activator.CreateInstance(wrapperType)!;
        });

        return handler.HandleAsync(command, _serviceProvider, cancellationToken);
    }

    public Task<Result<TResult>> SendAsync<TResult>(
        ICommand<TResult> command,
        CancellationToken cancellationToken = default)
    {
        if (command is null)
            throw new ArgumentNullException(nameof(command));

        var handler = (CommandHandlerWrapper<TResult>)_cache.GetOrAdd(command.GetType(), static x =>
        {
            var wrapperType = typeof(CommandHandlerWrapperImplementation<,>).MakeGenericType(x, typeof(TResult));
            return Activator.CreateInstance(wrapperType)!;
        });

        return handler.HandleAsync(command, _serviceProvider, cancellationToken);
    }

    public Task<Result<TResult>> SendAsync<TResult>(
        IQuery<TResult> query,
        CancellationToken cancellationToken = default)
    {
        if (query is null)
            throw new ArgumentNullException(nameof(query));

        var handler = (QueryHandlerWrapper<TResult>)_cache.GetOrAdd(query.GetType(), static x =>
        {
            var wrapperType = typeof(QueryHandlerWrapperImplementation<,>).MakeGenericType(x, typeof(TResult));
            return Activator.CreateInstance(wrapperType)!;
        });

        return handler.HandleAsync(query, _serviceProvider, cancellationToken);
    }
}