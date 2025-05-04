using System.Collections.Generic;
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
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetReservationsQueryHandler> _logger;

        public GetReservationsQueryHandler(
            IReservationRepository reservationRepository,
            IMapper mapper,
            ILogger<GetReservationsQueryHandler> logger)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
            return dtos;
        }
    }
} 