using System;
using System.Collections.Generic;
using LibraryManagement.Domain.Interfaces;

namespace LibraryManagement.Domain.Entities
{
    public class Tag : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
} 