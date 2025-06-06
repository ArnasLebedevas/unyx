using AutoMapper;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Features.Auth.SignUp;

public class SignUpMapper : Profile
{
    public SignUpMapper()
    {
        CreateMap<User, AuthResponseDto>();
        CreateMap<CreateUserDto, User>();
    }
}
