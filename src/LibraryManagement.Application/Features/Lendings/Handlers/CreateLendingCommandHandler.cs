using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.Features.Lendings.Commands;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Lendings.Handlers
{
    public class CreateLendingCommandHandler : IRequestHandler<CreateLendingCommand, Guid>
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLendingCommandHandler> _logger;

        public CreateLendingCommandHandler(
            ILendingRepository lendingRepository,
            IBookRepository bookRepository,
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<CreateLendingCommandHandler> logger)
        {
            _lendingRepository = lendingRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateLendingCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
                throw new Exception("Book not found.");
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found.");
            var lending = _mapper.Map<Lending>(request);
            lending.Id = Guid.NewGuid();
            await _lendingRepository.AddAsync(lending);
            _logger.LogInformation("Lending created with Id: {LendingId}", lending.Id);
            return lending.Id;
        }
    }
} 