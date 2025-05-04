using System;

namespace LibraryManagement.Application.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
} 