using System;
using System.Collections.Generic;

namespace LibraryManagement.Application.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string CategoryName { get; set; }
        public required List<string> Tags { get; set; }
        public required string Status { get; set; }
    }
} 