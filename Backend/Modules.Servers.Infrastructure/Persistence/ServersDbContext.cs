using Microsoft.EntityFrameworkCore;
using Modules.Servers.Application.Common.Interfaces;
using Modules.Servers.Domain.Entities;

namespace Modules.Servers.Infrastructure.Persistence;

public class ServersDbContext(DbContextOptions<ServersDbContext> options) : DbContext(options), IServersDbContext
{
    public DbSet<Server> Servers => Set<Server>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("servers");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServersDbContext).Assembly);
    }
}
