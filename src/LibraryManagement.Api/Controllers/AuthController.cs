using LibraryManagement.Api.DTOs;
using LibraryManagement.Api.Services;
using LibraryManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(IUserRepository userRepository, JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            // For demo: simple hash, in production use a secure hash
            var passwordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(request.Password));
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(u =>
                (u.UserName == request.UserNameOrEmail || u.Email == request.UserNameOrEmail) &&
                u.PasswordHash == passwordHash);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _jwtTokenService.GenerateToken(user.Id, user.UserName, user.Email);
            var expires = DateTime.UtcNow.AddMinutes(60); // Should match JWT settings
            return Ok(new LoginResponseDto
            {
                Token = token,
                ExpiresAt = expires,
                UserName = user.UserName,
                Email = user.Email
            });
        }
    }
} 