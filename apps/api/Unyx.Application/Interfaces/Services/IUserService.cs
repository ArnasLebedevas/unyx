using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services;

internal interface IUserService
{
    User CreateUser(CreateUserDto model);
}
