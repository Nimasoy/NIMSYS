using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Reservations.Queries;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Reservations.Handlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetReservationByIdQueryHandler> _logger;

        public GetReservationByIdQueryHandler(
            IReservationRepository reservationRepository,
            IMapper mapper,
            ILogger<GetReservationByIdQueryHandler> logger)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);
            if (reservation == null)
            {
                _logger.LogWarning("Reservation not found: {ReservationId}", request.Id);
                throw new Exception($"Reservation with Id {request.Id} not found.");
            }
            var dto = _mapper.Map<ReservationDto>(reservation);
            return dto;
        }
    }
} 