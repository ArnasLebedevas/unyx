using Unyx.Domain.Entities;

namespace Unyx.Application.Persistence.Read;

public interface IUserReadRepository : IReadRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}