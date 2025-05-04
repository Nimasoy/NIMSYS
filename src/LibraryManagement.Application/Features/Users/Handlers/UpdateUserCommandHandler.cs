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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<UpdateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                _logger.LogWarning("User not found for update: {UserId}", request.Id);
                throw new Exception($"User with Id {request.Id} not found.");
            }
            _mapper.Map(request, user);
            await _userRepository.UpdateAsync(user);
            _logger.LogInformation("User updated: {UserId}", user.Id);
            return Unit.Value;
        }
    }
} 