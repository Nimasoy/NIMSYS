using System.Collections.Generic;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }
} 