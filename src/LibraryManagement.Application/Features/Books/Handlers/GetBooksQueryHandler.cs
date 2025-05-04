using System.Collections.Generic;
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
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBooksQueryHandler> _logger;

        public GetBooksQueryHandler(
            IBookRepository bookRepository,
            IMapper mapper,
            ILogger<GetBooksQueryHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<BookDto>>(books);
            return dtos;
        }
    }
} 