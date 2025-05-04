using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Books.Queries;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Books.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBookByIdQueryHandler> _logger;

        public GetBookByIdQueryHandler(
            IBookRepository bookRepository,
            IMapper mapper,
            ILogger<GetBookByIdQueryHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                _logger.LogWarning("Book not found: {BookId}", request.Id);
                throw new Exception($"Book with Id {request.Id} not found.");
            }
            var dto = _mapper.Map<BookDto>(book);
            return dto;
        }
    }
} 