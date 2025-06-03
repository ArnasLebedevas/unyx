using Unyx.Application.Persistence;
using Unyx.Application.Persistence.Write;
using Unyx.Domain.Entities;
using Unyx.Persistence.Repositories.Write;

namespace Unyx.Persistence.Repositories;

public class UnitOfWork(UnyxDbContext context) : IUnitOfWork
{
    public IWriteRepository<User> Users { get; } = new WriteRepository<User>(context);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}