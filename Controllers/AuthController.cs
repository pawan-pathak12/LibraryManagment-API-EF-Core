using Library_Management_API.Data;
using Library_Management_API.Models;
using Library_Management_API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace Library_Management_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            this._applicationDbContext = applicationDbContext;
            this._configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _applicationDbContext.Users
                .FirstOrDefaultAsync(x => x.Email == newUser.Email);

            if (existingUser != null)
            {
                return BadRequest("Email is already registered.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            var appuser = new AppUser
            {
                FullName = newUser.FullName,
                Email = newUser.Email,
                Password = passwordHash
            };

            await _applicationDbContext.Users.AddAsync(appuser);
            await _applicationDbContext.SaveChangesAsync();

            return Ok("User Registered Successfully");
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserUser([FromBody] LoginUserDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Email == login.Email);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");

            }
            //verify password 
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
            if (!isPasswordValid)
            {
                return Unauthorized("Invalid email or password");
            }

            //build JWT token
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                  new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                  new Claim(ClaimTypes.Email,user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
               , SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            var jwt = tokenhandler.WriteToken(token);
            return Ok(new {token =jwt});
        }
    }
}
