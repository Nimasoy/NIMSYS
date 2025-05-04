using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Lendings.Commands;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Lendings.Handlers
{
    public class DeleteLendingCommandHandler : IRequestHandler<DeleteLendingCommand, Unit>
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly ILogger<DeleteLendingCommandHandler> _logger;

        public DeleteLendingCommandHandler(ILendingRepository lendingRepository, ILogger<DeleteLendingCommandHandler> logger)
        {
            _lendingRepository = lendingRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteLendingCommand request, CancellationToken cancellationToken)
        {
            var lending = await _lendingRepository.GetByIdAsync(request.Id);
            if (lending == null)
            {
                _logger.LogWarning("Lending not found for delete: {LendingId}", request.Id);
                throw new Exception($"Lending with Id {request.Id} not found.");
            }
            await _lendingRepository.DeleteAsync(lending);
            _logger.LogInformation("Lending deleted: {LendingId}", lending.Id);
            return Unit.Value;
        }
    }
} 