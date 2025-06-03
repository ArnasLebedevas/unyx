using Unyx.Application.Persistence.Write;
using Unyx.Domain.Entities;

namespace Unyx.Persistence.Repositories.Write;

public class WriteRepository<T>(UnyxDbContext context) : IWriteRepository<T> where T : BaseEntity
{
    protected readonly UnyxDbContext context = context;

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
    public void Add(T model) => context.Set<T>().Add(model);
    public void Update(T model) => context.Set<T>().Update(model);
    public void Delete(T model) => context.Set<T>().Remove(model);
}