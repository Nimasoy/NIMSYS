using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Application.Features.Users.Commands;

namespace LibraryManagement.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<UpdateUserDto, User>();
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
} 