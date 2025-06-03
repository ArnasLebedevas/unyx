using Unyx.Application.Persistence.Write;
using Unyx.Domain.Entities;

namespace Unyx.Application.Persistence;

public interface IUnitOfWork
{
    IWriteRepository<User> Users { get; }

    Task SaveChangesAsync();
}