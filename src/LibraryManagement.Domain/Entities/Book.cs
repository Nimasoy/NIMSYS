using System;
using System.Collections.Generic;
using LibraryManagement.Domain.Enums;
using LibraryManagement.Domain.Interfaces;

namespace LibraryManagement.Domain.Entities
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public BookStatus Status { get; set; }
        public ICollection<Lending> Lendings { get; set; } = new List<Lending>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
} 