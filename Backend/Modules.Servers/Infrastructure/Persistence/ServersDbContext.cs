using Microsoft.EntityFrameworkCore;
using Modules.Servers.Domain.Entities;

namespace Modules.Servers.Infrastructure.Persistence
{
    public class ServersDbContext(DbContextOptions<ServersDbContext> options) : DbContext(options)
    {
        public DbSet<Server> Servers => Set<Server>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("servers");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServersDbContext).Assembly);
        }
    }
}
