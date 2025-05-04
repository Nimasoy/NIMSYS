using MediatR;
using System;

namespace LibraryManagement.Application.Features.Reservations.Commands
{
    public class CreateReservationCommand : IRequest<Guid>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
} 