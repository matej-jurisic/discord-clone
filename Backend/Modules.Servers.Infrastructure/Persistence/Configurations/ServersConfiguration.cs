using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Servers.Domain.Entities;

namespace Modules.Servers.Infrastructure.Persistence.Configurations;

public class ServersConfiguration : IEntityTypeConfiguration<Server>
{
    public void Configure(EntityTypeBuilder<Server> builder)
    {
        builder.HasData(Server.Create(1, "Default Server", "My description"));
    }
}
