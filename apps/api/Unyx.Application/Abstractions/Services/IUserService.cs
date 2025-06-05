using Unyx.Application.Common.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Abstractions.Services;

public interface IUserService
{
    User CreateUser(CreateUserDto model);
}
