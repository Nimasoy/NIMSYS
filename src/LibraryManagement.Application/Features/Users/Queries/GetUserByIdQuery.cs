using System;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
} 