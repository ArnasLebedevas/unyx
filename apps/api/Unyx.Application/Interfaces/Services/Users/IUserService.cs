using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services.Users;

internal interface IUserService
{
    User CreateUser(CreateUserDto model);
}
