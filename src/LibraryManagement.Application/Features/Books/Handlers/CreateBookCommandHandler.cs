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
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateBookCommandHandler> _logger;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<CreateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            book.Id = Guid.NewGuid();
            await _bookRepository.AddAsync(book);
            _logger.LogInformation("Book created with Id: {BookId}", book.Id);
            return book.Id;
        }
    }
} 