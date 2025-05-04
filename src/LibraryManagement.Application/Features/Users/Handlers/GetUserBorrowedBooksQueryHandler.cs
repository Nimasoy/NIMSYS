using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Users.Queries;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Users.Handlers
{
    public class GetUserBorrowedBooksQueryHandler : IRequestHandler<GetUserBorrowedBooksQuery, IEnumerable<BorrowedBookDto>>
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetUserBorrowedBooksQueryHandler> _logger;

        public GetUserBorrowedBooksQueryHandler(
            ILendingRepository lendingRepository,
            IBookRepository bookRepository,
            ILogger<GetUserBorrowedBooksQueryHandler> logger)
        {
            _lendingRepository = lendingRepository;
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<BorrowedBookDto>> Handle(GetUserBorrowedBooksQuery request, CancellationToken cancellationToken)
        {
            var lendings = await _lendingRepository.GetByUserIdAsync(request.UserId);
            var borrowedBooks = new List<BorrowedBookDto>();
            foreach (var lending in lendings)
            {
                var book = await _bookRepository.GetByIdAsync(lending.BookId);
                borrowedBooks.Add(new BorrowedBookDto
                {
                    BookId = lending.BookId,
                    Title = book?.Title ?? string.Empty,
                    BorrowedAt = lending.BorrowedAt,
                    DueAt = lending.DueAt,
                    ReturnedAt = lending.ReturnedAt
                });
            }
            return borrowedBooks;
        }
    }
} 