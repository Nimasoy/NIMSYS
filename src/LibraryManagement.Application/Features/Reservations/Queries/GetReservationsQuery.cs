using System.Collections.Generic;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Reservations.Queries
{
    public class GetReservationsQuery : IRequest<IEnumerable<ReservationDto>>
    {
    }
} 