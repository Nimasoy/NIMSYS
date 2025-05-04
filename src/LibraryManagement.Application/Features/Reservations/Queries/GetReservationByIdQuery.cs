using System;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Reservations.Queries
{
    public class GetReservationByIdQuery : IRequest<ReservationDto>
    {
        public Guid Id { get; set; }
    }
} 