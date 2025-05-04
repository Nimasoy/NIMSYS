using System;
using System.Collections.Generic;

namespace LibraryManagement.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public int MaxBorrowLimit { get; set; }
        public required List<BorrowedBookDto> BorrowedBooks { get; set; }
    }

    public class BorrowedBookDto
    {
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime DueAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
} 