using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Books.Commands;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Books.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<DeleteBookCommandHandler> _logger;

        public DeleteBookCommandHandler(IBookRepository bookRepository, ILogger<DeleteBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                _logger.LogWarning("Book not found for delete: {BookId}", request.Id);
                throw new Exception($"Book with Id {request.Id} not found.");
            }
            await _bookRepository.DeleteAsync(book);
            _logger.LogInformation("Book deleted: {BookId}", book.Id);
            return Unit.Value;
        }
    }
} 