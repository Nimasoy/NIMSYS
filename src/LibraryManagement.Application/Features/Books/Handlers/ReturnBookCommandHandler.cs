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
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILendingRepository _lendingRepository;
        private readonly ILogger<ReturnBookCommandHandler> _logger;

        public ReturnBookCommandHandler(
            IBookRepository bookRepository,
            IUserRepository userRepository,
            ILendingRepository lendingRepository,
            ILogger<ReturnBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _lendingRepository = lendingRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null || book.Status != BookStatus.Borrowed)
                throw new Exception("Book is not currently borrowed.");

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found.");

            var lending = await _lendingRepository.GetActiveLendingAsync(book.Id, user.Id);
            if (lending == null)
                throw new Exception("No active lending record found for this book and user.");

            lending.ReturnedAt = DateTime.UtcNow;
            await _lendingRepository.UpdateAsync(lending);
            book.Status = BookStatus.Available;
            await _bookRepository.UpdateAsync(book);
            _logger.LogInformation("Book {BookId} returned by user {UserId}", book.Id, user.Id);
            return Unit.Value;
        }
    }
} 