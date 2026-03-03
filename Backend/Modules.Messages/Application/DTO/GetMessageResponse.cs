using Modules.Messages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Messages.Application.DTO;

public record GetMessageResponse
{
    public long MessageId { get; set; }
    public string Content { get; set; } = string.Empty;

    public GetMessageResponse(Message message)
    {
        MessageId = message.MessageId;
        Content = message.Content;
    }
}

