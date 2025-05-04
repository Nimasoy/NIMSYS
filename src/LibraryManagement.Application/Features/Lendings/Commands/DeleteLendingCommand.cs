using MediatR;
using System;

namespace LibraryManagement.Application.Features.Lendings.Commands
{
    public class DeleteLendingCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
} 