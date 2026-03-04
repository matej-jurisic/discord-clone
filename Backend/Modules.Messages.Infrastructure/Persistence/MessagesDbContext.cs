using Microsoft.EntityFrameworkCore;
using Modules.Messages.Application.Common.Interfaces;
using Modules.Messages.Domain.Entities;

namespace Modules.Messages.Infrastructure.Persistence;

public class MessagesDbContext(DbContextOptions<MessagesDbContext> options) : DbContext(options), IMessagesDbContext
{
    public DbSet<Message> Messages => Set<Message>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("messages");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessagesDbContext).Assembly);
    }
}
