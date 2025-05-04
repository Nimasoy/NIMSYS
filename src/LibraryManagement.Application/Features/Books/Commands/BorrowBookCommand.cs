using System;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands
{
    public class BorrowBookCommand : IRequest<Unit>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
} 