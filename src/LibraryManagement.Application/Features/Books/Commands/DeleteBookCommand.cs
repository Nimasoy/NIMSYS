using System;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
} 