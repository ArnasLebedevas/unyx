using Unyx.Domain.Entities;

namespace Unyx.Application.Persistence.Read;

public interface IReadRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
}