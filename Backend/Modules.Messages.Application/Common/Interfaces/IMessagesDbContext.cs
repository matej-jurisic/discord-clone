using Microsoft.EntityFrameworkCore;
using Modules.Messages.Domain.Entities;

namespace Modules.Messages.Application.Common.Interfaces;
public interface IMessagesDbContext
{
    DbSet<Message> Messages { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
