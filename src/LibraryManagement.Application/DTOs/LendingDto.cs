using System;

namespace LibraryManagement.Application.DTOs
{
    public class LendingDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public required string BookTitle { get; set; }
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime DueAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
} 