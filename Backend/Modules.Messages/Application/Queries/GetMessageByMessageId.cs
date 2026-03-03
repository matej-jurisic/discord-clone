using Microsoft.EntityFrameworkCore;
using Modules.Messages.Application.DTO;
using Modules.Messages.Infrastructure.Persistence;
using Shared.Kernel.CQRS;
using Shared.Kernel.Results;

namespace Modules.Messages.Application.Queries;

public record GetMessageByMessageId(long MessageId) : IQuery<GetMessageResponse>;

public class GetMessageByMessageIdHandler(MessagesDbContext context) : IQueryHandler<GetMessageByMessageId, GetMessageResponse>
{
    public async Task<Result<GetMessageResponse>> HandleAsync(GetMessageByMessageId query, CancellationToken cancellationToken = default)
    {
        var message = await context.Messages
            .Where(x => x.MessageId == query.MessageId)
            .Select(x => new GetMessageResponse(x))
            .FirstOrDefaultAsync(cancellationToken);

        return message is null
            ? Result.Failure(ResultStatusCodes.BadRequest, "Error")
            : Result.Success(message);
    }
}
