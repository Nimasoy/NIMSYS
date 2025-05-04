namespace LibraryManagement.Api.DTOs
{
    public class LoginRequestDto
    {
        public required string UserNameOrEmail { get; set; }
        public required string Password { get; set; }
    }
} 