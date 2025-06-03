using Unyx.Domain.Entities;

namespace Unyx.Application.Persistence.Write;

public interface IWriteRepository<T> where T : BaseEntity
{
    Task SaveChangesAsync();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}