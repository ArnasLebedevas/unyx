using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services;

public interface IUserService
{
    User CreateUser(CreateUserDto model);
}
