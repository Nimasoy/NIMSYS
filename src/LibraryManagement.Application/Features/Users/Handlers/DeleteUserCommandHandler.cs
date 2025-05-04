using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Users.Commands;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserRepository userRepository, ILogger<DeleteUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                _logger.LogWarning("User not found for delete: {UserId}", request.Id);
                throw new Exception($"User with Id {request.Id} not found.");
            }
            await _userRepository.DeleteAsync(user);
            _logger.LogInformation("User deleted: {UserId}", user.Id);
            return Unit.Value;
        }
    }
} 