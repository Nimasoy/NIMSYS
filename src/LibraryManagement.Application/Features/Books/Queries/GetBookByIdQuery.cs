using System;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public Guid Id { get; set; }
    }
} 