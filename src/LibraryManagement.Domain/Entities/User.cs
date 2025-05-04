using System;
using System.Collections.Generic;
using LibraryManagement.Domain.Interfaces;

namespace LibraryManagement.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public ICollection<Lending> BorrowedBooks { get; set; } = new List<Lending>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public int MaxBorrowLimit { get; set; } = 5;
    }
} 