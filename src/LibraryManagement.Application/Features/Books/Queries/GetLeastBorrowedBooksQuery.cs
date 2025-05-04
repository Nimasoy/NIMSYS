using System.Collections.Generic;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries
{
    public class GetLeastBorrowedBooksQuery : IRequest<IEnumerable<BookDto>>
    {
        public int Count { get; set; }
    }
}