using System;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Lendings.Queries
{
    public class GetLendingByIdQuery : IRequest<LendingDto>
    {
        public Guid Id { get; set; }
    }
} 