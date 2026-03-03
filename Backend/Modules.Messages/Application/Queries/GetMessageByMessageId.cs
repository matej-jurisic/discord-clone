<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> dev
using Modules.Messages.Application.DTO;
using Modules.Messages.Infrastructure.Persistence;
using Shared.Kernel.CQRS;
using Shared.Kernel.Results;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Messages.Application.Queries;

public record GetMessageByMessageId(long messageId) : IQuery<GetMessageResponse>;
=======

namespace Modules.Messages.Application.Queries;

public record GetMessageByMessageId(long MessageId) : IQuery<GetMessageResponse>;
>>>>>>> dev

public class GetMessageByMessageIdHandler(MessagesDbContext context) : IQueryHandler<GetMessageByMessageId, GetMessageResponse>
{
    public async Task<Result<GetMessageResponse>> HandleAsync(GetMessageByMessageId query, CancellationToken cancellationToken = default)
    {
        var message = await context.Messages
<<<<<<< HEAD
            .Where(x => x.MessageId == query.messageId)
            .Select(x => new GetMessageResponse(x))
            .FirstOrDefaultAsync();
=======
            .Where(x => x.MessageId == query.MessageId)
            .Select(x => new GetMessageResponse(x))
            .FirstOrDefaultAsync(cancellationToken);
>>>>>>> dev

        return message is null
            ? Result.Failure(ResultStatusCodes.BadRequest, "Error")
            : Result.Success(message);
    }
}
