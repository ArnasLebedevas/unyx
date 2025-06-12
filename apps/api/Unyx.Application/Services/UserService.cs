using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.Services;
using Unyx.Domain.Entities;

namespace Unyx.Application.Services;

internal class UserService(IPasswordHasher<User> passwordHasher, IMapper mapper) : IUserService
{
    public User CreateUser(CreateUserDto model)
    {
        var user = mapper.Map<User>(model);

        if (!string.IsNullOrEmpty(model.Password))
            user.PasswordHash = passwordHasher.HashPassword(user, model.Password);

        return user;
    }
}
