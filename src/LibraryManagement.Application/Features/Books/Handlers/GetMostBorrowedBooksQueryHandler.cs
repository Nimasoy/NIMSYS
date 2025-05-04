using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Books.Queries;
using LibraryManagement.Domain.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Handlers
{
    public class GetMostBorrowedBooksQueryHandler : IRequestHandler<GetMostBorrowedBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetMostBorrowedBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetMostBorrowedBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetMostBorrowedAsync(request.Count);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}