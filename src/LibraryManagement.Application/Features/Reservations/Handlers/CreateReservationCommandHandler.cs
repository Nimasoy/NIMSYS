using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.Features.Reservations.Commands;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Reservations.Handlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateReservationCommandHandler> _logger;

        public CreateReservationCommandHandler(
            IReservationRepository reservationRepository,
            IBookRepository bookRepository,
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<CreateReservationCommandHandler> logger)
        {
            _reservationRepository = reservationRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
                throw new Exception("Book not found.");
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found.");
            var reservation = _mapper.Map<Reservation>(request);
            reservation.Id = Guid.NewGuid();
            await _reservationRepository.AddAsync(reservation);
            _logger.LogInformation("Reservation created with Id: {ReservationId}", reservation.Id);
            return reservation.Id;
        }
    }
}
