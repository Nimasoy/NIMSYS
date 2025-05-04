using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Books.Commands;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Books.Handlers
{
    public class BorrowBookCommandHandler(
        IBookRepository bookRepository,
        IUserRepository userRepository,
        ILendingRepository lendingRepository,
        ILogger<BorrowBookCommandHandler> logger) : IRequestHandler<BorrowBookCommand, Unit>
    {

        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ILendingRepository _lendingRepository = lendingRepository;
        private readonly ILogger<BorrowBookCommandHandler> _logger = logger;

        public async Task<Unit> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null || book.Status != BookStatus.Available)
                throw new Exception("Book is not available for borrowing.");

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found.");

            var userBorrowedCount = await _lendingRepository.GetActiveBorrowedCountByUserAsync(user.Id);
            if (userBorrowedCount >= user.MaxBorrowLimit)
                throw new Exception("User has reached the maximum borrow limit.");

            var lending = new Lending
            {
                Id = Guid.NewGuid(),
                BookId = book.Id,
                UserId = user.Id,
                Book = book,
                User = user,
                BorrowedAt = DateTime.UtcNow,
                DueAt = DateTime.UtcNow.AddDays(14)
            };
            await _lendingRepository.AddAsync(lending);
            book.Status = BookStatus.Borrowed;
            await _bookRepository.UpdateAsync(book);
            _logger.LogInformation("Book {BookId} borrowed by user {UserId}", book.Id, user.Id);
            return Unit.Value;
        }
    }
} 