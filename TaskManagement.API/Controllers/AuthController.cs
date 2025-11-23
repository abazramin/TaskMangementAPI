using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using TaskManagement.Application;
using TaskManagement.Domain.DTOs;
using TaskManagement.Domain;
using TaskManagement.Infrasturcture;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly IJwtService _jwt;

		public AuthController(AppDbContext context, IJwtService jwt)
		{
			_context = context;
			_jwt = jwt;
		}

		[HttpGet("Users")]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _context.Users
				.Select(u => new { u.id, u.name, u.email, u.Role })
				.ToListAsync();
			return Ok(users);
		}


		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDto dto)
		{
			var passwordBytes = BCrypt.PasswordToByteArray(dto.Password.ToCharArray());
			var salt = new byte[16]; 
			using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
			{
				rng.GetBytes(salt);
			}
			var hashBytes = BCrypt.Generate(passwordBytes, salt, 10); 
			var passwordHash = Convert.ToBase64String(hashBytes);

			var user = new User
			{
				name = dto.Name,
				email = dto.Email,
				passwordHash = passwordHash,
				Role = dto.Role
			};

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return Ok(new { user.id, user.email , user.Role});
		}


		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto dto)
		{
			var user = await _context.Users.FirstOrDefaultAsync(x => x.email == dto.Email);
			if (user == null) return Unauthorized("Invalid email");

			// Use the custom BCrypt class directly instead of BCrypt.Net.BCrypt
			var passwordBytes = BCrypt.PasswordToByteArray(dto.Password.ToCharArray());
			var storedHashBytes = Convert.FromBase64String(user.passwordHash);
			var salt = new byte[16];
			Array.Copy(storedHashBytes, 0, salt, 0, 16);
			var hashBytes = BCrypt.Generate(passwordBytes, salt, 10);
			var computedHash = Convert.ToBase64String(hashBytes);

			if (computedHash != user.passwordHash)
				return Unauthorized("Wrong password");

			var token = _jwt.GenerateToken(user);
			return Ok(new { token });
		}
	}
}
