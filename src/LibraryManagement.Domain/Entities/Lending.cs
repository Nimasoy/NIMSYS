using System;
using LibraryManagement.Domain.Interfaces;

namespace LibraryManagement.Domain.Entities
{
    public class Lending : IEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public required Book Book { get; set; }
        public Guid UserId { get; set; }
        public required User User { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime DueAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
} 