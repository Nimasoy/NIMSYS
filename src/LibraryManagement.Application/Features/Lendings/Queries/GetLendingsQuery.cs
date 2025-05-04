using System.Collections.Generic;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Lendings.Queries
{
    public class GetLendingsQuery : IRequest<IEnumerable<LendingDto>>
    {
    }
} 