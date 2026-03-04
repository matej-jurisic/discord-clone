using Modules.Messages.Domain.Entities;

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

