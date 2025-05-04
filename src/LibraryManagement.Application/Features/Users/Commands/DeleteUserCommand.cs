using MediatR;
using System;

namespace LibraryManagement.Application.Features.Users.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
} 