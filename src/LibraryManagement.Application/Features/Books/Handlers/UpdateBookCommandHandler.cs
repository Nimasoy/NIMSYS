using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.Features.Books.Commands;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Books.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBookCommandHandler> _logger;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<UpdateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                _logger.LogWarning("Book not found for update: {BookId}", request.Id);
                throw new Exception($"Book with Id {request.Id} not found.");
            }
            _mapper.Map(request, book);
            await _bookRepository.UpdateAsync(book);
            _logger.LogInformation("Book updated: {BookId}", book.Id);
            return Unit.Value;
        }
    }
} 