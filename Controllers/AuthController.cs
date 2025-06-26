using BCrypt.Net;
using GenieWeb.Data;
using GenieWeb.Models;
using GenieWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GenieWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly EmailService _emailService;

        public AuthController(AppDbContext context, IConfiguration config, EmailService emailService)
        {
            _context = context;
            _config = config;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Invalid registration data.");

            if (dto.Password != dto.ConfirmPassword)
            {
                return BadRequest("Passwords do not match.");
            }

            if (_context.Users.Any(u => u.Email == dto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var token = Guid.NewGuid().ToString();

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = hashedPassword,
                Status = "Inactive",
                ActivationToken = token
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            Task.Run(() =>
            {
                try
                {
                    var activationLink = Url.Action("Activate", "Auth", new { token = token }, Request.Scheme);
                    _emailService.SendActivationEmail(user.Email, activationLink);
                    Console.WriteLine($"✅ Activation email sent to {user.Email}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Failed to send activation email: " + ex.Message);
                }
            });

            return Ok("Registration successful.");
        }

        [HttpGet]
        public IActionResult Activate(string token)
        {
            var user = _context.Users.FirstOrDefault(u => u.ActivationToken == token);
            if (user == null) return NotFound("Invalid or expired activation link.");

            user.Status = "Active";
            user.ActivationToken = null;
            _context.SaveChanges();

            return Content("✅ Your account has been activated. You can now log in.");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                return BadRequest("Invalid login details.");

            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null || user.Status != "Active")
                return BadRequest("Account not activated or invalid email.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return BadRequest("Invalid password.");

            var token = GenerateJwtToken(user);

            // ✅ Save token & login flag in session
            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetString("IsLoggedIn", "true");
            HttpContext.Session.SetString("UserName", user.FullName); // optional: for greeting

            return Ok("Login successful");
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }



        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtSettings:ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
