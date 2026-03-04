using Kernel.CQRS;
using Kernel.Results;
using Microsoft.EntityFrameworkCore;
using Modules.Messages.Application.Common.Interfaces;
using Modules.Messages.Application.DTO;

namespace Modules.Messages.Application.Queries;

public record GetMessageByMessageId(long MessageId) : IQuery<GetMessageResponse>;

public class GetMessageByMessageIdHandler(IMessagesDbContext context) : IQueryHandler<GetMessageByMessageId, GetMessageResponse>
{
    private readonly IMessagesDbContext _context = context;

    public async Task<Result<GetMessageResponse>> HandleAsync(GetMessageByMessageId query, CancellationToken cancellationToken = default)
    {
        var message = await _context.Messages
            .Where(x => x.MessageId == query.MessageId)
            .Select(x => new GetMessageResponse(x))
            .FirstOrDefaultAsync(cancellationToken);

        return message is null
            ? Result.Failure(ResultStatusCodes.BadRequest, "Error")
            : Result.Success(message);
    }
}
