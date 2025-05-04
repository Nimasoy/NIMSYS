using MediatR;
using System;

namespace LibraryManagement.Application.Features.Reservations.Commands
{
    public class DeleteReservationCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
} 