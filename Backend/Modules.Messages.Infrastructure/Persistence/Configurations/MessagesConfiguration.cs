using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Messages.Domain.Entities;

namespace Messages.Infrastructure.Persistence.Configurations;

public class MessagesConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasData(new Message(1, "Test"));
    }
}