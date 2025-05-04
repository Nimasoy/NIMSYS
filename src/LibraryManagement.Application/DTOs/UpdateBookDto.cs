using System;
using System.Collections.Generic;

namespace LibraryManagement.Application.DTOs
{
    public class UpdateBookDto
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public Guid CategoryId { get; set; }
        public required List<Guid> TagIds { get; set; }
        public required string Status { get; set; }
    }
} 