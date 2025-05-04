using System;
using System.Collections.Generic;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Users.Queries
{
    public class GetUserBorrowedBooksQuery : IRequest<IEnumerable<BorrowedBookDto>>
    {
        public Guid UserId { get; set; }
    }
}
