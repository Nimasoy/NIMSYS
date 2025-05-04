using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.Features.Users.Commands;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.Id = Guid.NewGuid();
            // Hash password (for demo, use a simple hash; in production, use a secure hash)
            user.PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(request.Password));
            await _userRepository.AddAsync(user);
            _logger.LogInformation("User created with Id: {UserId}", user.Id);
            return user.Id;
        }
    }
} 