using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Messages.Domain.Entities;

public class Message
{
    public long MessageId { get; private set; }
    public string Content { get; private set; } = string.Empty;

    private Message() { }

    public Message(long messageId, string content)
    {
        MessageId = messageId;
        Content = content;
    }
}