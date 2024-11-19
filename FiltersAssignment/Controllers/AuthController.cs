using Microsoft.AspNetCore.Mvc;
using FiltersAssignment.Data;
using FiltersAssignment.Services;
using FiltersAssignment.Model;

namespace FiltersAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly FilterDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(FilterDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Registers a new user and assigns a default role if none is provided.
        /// </summary>
        /// <param name="user">The user object containing registration details.</param>
        /// <returns>Success or error message depending on registration result.</returns>
        [HttpPost("register")]

        public IActionResult Register([FromBody] User user)
        {
            // Check if role is null or empty, and assign default
            if (string.IsNullOrEmpty(user.Role))
            {
                user.Role = "User";  // Default role
            }
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                return BadRequest("Username already exists.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);

            if (user == null) return Unauthorized("Invalid credentials");

            var token = JwtHelper.GenerateToken(
                user.Username,
                user.Role,
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"]);

            return Ok(new { Token = token });
        }
    }


}

