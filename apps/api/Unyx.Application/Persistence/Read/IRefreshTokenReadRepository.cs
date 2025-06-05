using Unyx.Domain.Entities;

namespace Unyx.Application.Persistence.Read;

public interface IRefreshTokenReadRepository : IReadRepository<RefreshToken>
{
    Task<RefreshToken?> GetByUserIdAsync(Guid Id);
}