using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Reservations.Commands;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Reservations.Handlers
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ILogger<DeleteReservationCommandHandler> _logger;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository, ILogger<DeleteReservationCommandHandler> logger)
        {
            _reservationRepository = reservationRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);
            if (reservation == null)
            {
                _logger.LogWarning("Reservation not found for delete: {ReservationId}", request.Id);
                throw new Exception($"Reservation with Id {request.Id} not found.");
            }
            await _reservationRepository.DeleteAsync(reservation);
            _logger.LogInformation("Reservation deleted: {ReservationId}", reservation.Id);
            return Unit.Value;
        }
    }
} 