using Microsoft.EntityFrameworkCore;
using Modules.Servers.Infrastructure.Persistence;
using Shared.Kernel.CQRS;
using Shared.Kernel.Results;

namespace Modules.Servers.Application.Queries
{
    public record GetDummyQuery(string message) : IQuery<string>;

    public class GetDummyHandler(ServersDbContext context) : IQueryHandler<GetDummyQuery, string>
    {
        public async Task<Result<string>> HandleAsync(
            GetDummyQuery query,
            CancellationToken cancellationToken = default)
        {
            var server = await context.Servers.FirstOrDefaultAsync(cancellationToken);

            var response = $"{query.message} - Server: {server?.Name.ToString() ?? "none"}";

            return Result.Success(response);
        }
    }
}
