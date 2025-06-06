using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Abstractions.Services;

public interface IUserService
{
    User CreateUser(CreateUserDto model);
}
