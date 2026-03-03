using Microsoft.EntityFrameworkCore;
using Modules.Messages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Messages.Infrastructure.Persistence;

public class MessagesDbContext(DbContextOptions<MessagesDbContext> options) : DbContext(options)
{
    public DbSet<Message> Messages => Set<Message>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("messages");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessagesDbContext).Assembly);
    }
}
