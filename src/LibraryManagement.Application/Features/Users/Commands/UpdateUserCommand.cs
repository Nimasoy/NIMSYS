using MediatR;
using System;

namespace LibraryManagement.Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public int MaxBorrowLimit { get; set; }
    }
} 