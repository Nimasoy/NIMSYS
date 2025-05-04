namespace LibraryManagement.Application.DTOs
{
    public class CreateUserDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public int MaxBorrowLimit { get; set; } = 5;
    }
} 