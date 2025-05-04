using System;
using System.Collections.Generic;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public Guid CategoryId { get; set; }
        public required List<Guid> TagIds { get; set; }
        public required string Status { get; set; }
    }
} 