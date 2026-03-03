<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Modules.Messages.Application.Queries;
using Shared.Kernel.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using Microsoft.AspNetCore.Mvc;
using Modules.Messages.Application.Queries;
using Shared.Kernel.CQRS;
>>>>>>> dev

namespace Modules.Messages.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController(IMediator mediator) : ControllerBase
{
<<<<<<< HEAD
    [HttpGet("[action]")]
=======
    [HttpGet("{messageId}")]
>>>>>>> dev
    public async Task<IActionResult> GetMessageByMessageId(long messageId)
        => Ok(await mediator.SendAsync(new GetMessageByMessageId(messageId)));
}