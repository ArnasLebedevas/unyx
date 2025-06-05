using AutoMapper;
using Unyx.Application.Common.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Features.Auth.SignUp;

public class SignUpMapping : Profile
{
    public SignUpMapping()
    {
        CreateMap<User, AuthResponseDto>();
        CreateMap<CreateUserDto, User>();
    }
}
