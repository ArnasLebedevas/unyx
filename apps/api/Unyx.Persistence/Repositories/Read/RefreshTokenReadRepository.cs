using Microsoft.EntityFrameworkCore;
using Unyx.Application.Persistence.Read;
using Unyx.Domain.Entities;

namespace Unyx.Persistence.Repositories.Read;

public class RefreshTokenReadRepository(UnyxDbContext context) : ReadRepository<RefreshToken>(context), IRefreshTokenReadRepository
{
    public async Task<RefreshToken?> GetByUserIdAsync(Guid userId) =>
        await context.Set<RefreshToken>().FirstOrDefaultAsync(refresh => refresh.UserId == userId);
}