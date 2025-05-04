using System;

namespace LibraryManagement.Application.DTOs
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public required string BookTitle { get; set; }
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
} 