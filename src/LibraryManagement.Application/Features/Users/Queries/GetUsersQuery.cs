using System.Collections.Generic;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Users.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
} 