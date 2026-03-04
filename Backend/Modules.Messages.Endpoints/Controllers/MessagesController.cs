using Kernel.CQRS;
using Microsoft.AspNetCore.Mvc;
using Modules.Messages.Application.Queries;

namespace Modules.Messages.Endpoints.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{messageId}")]
    public async Task<IActionResult> GetMessageByMessageId(long messageId)
        => Ok(await mediator.SendAsync(new GetMessageByMessageId(messageId)));
}
