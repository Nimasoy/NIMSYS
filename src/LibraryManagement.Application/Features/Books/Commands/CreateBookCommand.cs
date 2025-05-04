using System;
using System.Collections.Generic;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public Guid CategoryId { get; set; }
        public required List<Guid> TagIds { get; set; }
    }
} 