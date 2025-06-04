using Microsoft.EntityFrameworkCore;
using Unyx.Application.Persistence.Read;
using Unyx.Domain.Entities;

namespace Unyx.Persistence.Repositories.Read;

public class RefreshTokenReadRepository(UnyxDbContext context) : ReadRepository<RefreshToken>(context), IRefreshTokenReadRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token) =>
       await context.Set<RefreshToken>().FirstOrDefaultAsync(refresh => refresh.Token == token);

}