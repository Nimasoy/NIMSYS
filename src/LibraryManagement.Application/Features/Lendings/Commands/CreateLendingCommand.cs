using MediatR;
using System;

namespace LibraryManagement.Application.Features.Lendings.Commands
{
    public class CreateLendingCommand : IRequest<Guid>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime DueAt { get; set; }
    }
} 