using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Books.Queries;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using System.Linq;

namespace LibraryManagement.Application.Features.Books.Handlers
{
    public class GetLeastBorrowedBooksQueryHandler : IRequestHandler<GetLeastBorrowedBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetLeastBorrowedBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetLeastBorrowedBooksQuery request, CancellationToken cancellationToken)
        {
            // If you have a GetLeastBorrowedAsync in your repo, use it. Otherwise, do it here:
            var allBooks = await _bookRepository.GetAllAsync();
            var leastBorrowed = allBooks
                .OrderBy(b => b.Lendings.Count)
                .Take(request.Count);

            return _mapper.Map<IEnumerable<BookDto>>(leastBorrowed);
        }
    }
}