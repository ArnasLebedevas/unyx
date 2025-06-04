using Microsoft.EntityFrameworkCore;
using Unyx.Application.Persistence.Read;
using Unyx.Domain.Entities;

namespace Unyx.Persistence.Repositories.Read;

public class UserReadRepository(UnyxDbContext context) : ReadRepository<User>(context), IUserReadRepository
{
    public async Task<User?> GetUserByEmailAsync(string email) => await context.Set<User>().FirstOrDefaultAsync(user => user.Email == email);
}