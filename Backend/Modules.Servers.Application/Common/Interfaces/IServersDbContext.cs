using Microsoft.EntityFrameworkCore;
using Modules.Servers.Domain.Entities;

namespace Modules.Servers.Application.Common.Interfaces;

public interface IServersDbContext
{
    DbSet<Server> Servers { get; }
}
