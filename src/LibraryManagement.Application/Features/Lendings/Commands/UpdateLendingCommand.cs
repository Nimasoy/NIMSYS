using MediatR;
using System;

namespace LibraryManagement.Application.Features.Lendings.Commands
{
    public class UpdateLendingCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
} 