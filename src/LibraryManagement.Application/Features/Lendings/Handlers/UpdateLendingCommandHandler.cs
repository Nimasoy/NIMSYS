using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Lendings.Commands;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Lendings.Handlers
{
    public class UpdateLendingCommandHandler : IRequestHandler<UpdateLendingCommand, Unit>
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly ILogger<UpdateLendingCommandHandler> _logger;

        public UpdateLendingCommandHandler(ILendingRepository lendingRepository, ILogger<UpdateLendingCommandHandler> logger)
        {
            _lendingRepository = lendingRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateLendingCommand request, CancellationToken cancellationToken)
        {
            var lending = await _lendingRepository.GetByIdAsync(request.Id);
            if (lending == null)
            {
                _logger.LogWarning("Lending not found for update: {LendingId}", request.Id);
                throw new Exception($"Lending with Id {request.Id} not found.");
            }
            lending.ReturnedAt = request.ReturnedAt;
            await _lendingRepository.UpdateAsync(lending);
            _logger.LogInformation("Lending updated: {LendingId}", lending.Id);
            return Unit.Value;
        }
    }
} 