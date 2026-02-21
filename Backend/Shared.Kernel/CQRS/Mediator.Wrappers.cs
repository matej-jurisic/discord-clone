using Microsoft.Extensions.DependencyInjection;
using Shared.Kernel.Results;

namespace Shared.Kernel.CQRS
{
    public sealed partial class Mediator
    {
        private abstract class QueryHandlerWrapper<TResult>
        {
            public abstract Task<Result<TResult>> HandleAsync(
                IQuery<TResult> query,
                IServiceProvider serviceProvider,
                CancellationToken cancellationToken
            );
        }

        private abstract class CommandHandlerWrapper
        {
            public abstract Task<Result> HandleAsync(
                ICommand command,
                IServiceProvider serviceProvider,
                CancellationToken cancellationToken
            );
        }

        private abstract class CommandHandlerWrapper<TResult>
        {
            public abstract Task<Result<TResult>> HandleAsync(
                ICommand<TResult> command,
                IServiceProvider serviceProvider,
                CancellationToken cancellationToken
            );
        }


        private sealed class QueryHandlerWrapperImplementation<TQuery, TResult>
            : QueryHandlerWrapper<TResult> where TQuery : IQuery<TResult>
        {
            public override Task<Result<TResult>> HandleAsync(
                IQuery<TResult> query,
                IServiceProvider serviceProvider,
                CancellationToken cancellationToken)
            {
                var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
                return handler.HandleAsync((TQuery)query, cancellationToken);
            }
        }

        private sealed class CommandHandlerWrapperImplementation<TCommand>
            : CommandHandlerWrapper where TCommand : ICommand
        {
            public override Task<Result> HandleAsync(
                ICommand command,
                IServiceProvider serviceProvider,
                CancellationToken cancellationToken)
            {
                var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
                return handler.HandleAsync((TCommand)command, cancellationToken);
            }
        }

        private sealed class CommandHandlerWrapperImplementation<TCommand, TResult>
            : CommandHandlerWrapper<TResult> where TCommand : ICommand<TResult>
        {
            public override Task<Result<TResult>> HandleAsync(
                ICommand<TResult> command,
                IServiceProvider serviceProvider,
                CancellationToken cancellationToken)
            {
                var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
                return handler.HandleAsync((TCommand)command, cancellationToken);
            }
        }
    }
}
