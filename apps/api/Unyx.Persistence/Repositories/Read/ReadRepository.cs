using Unyx.Application.Persistence.Read;
using Unyx.Domain.Entities;

namespace Unyx.Persistence.Repositories.Read;

public class ReadRepository<T>(UnyxDbContext context) : IReadRepository<T> where T : BaseEntity
{
    protected readonly UnyxDbContext context = context;

    public async Task<T?> GetByIdAsync(Guid id) => await context.Set<T>().FindAsync(id);
}
