using MediatR;
using System;

namespace LibraryManagement.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public int MaxBorrowLimit { get; set; } = 5;
    }
} 