namespace LibraryManagement.Application.DTOs
{
    public class UpdateUserDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public int MaxBorrowLimit { get; set; }
    }
} 