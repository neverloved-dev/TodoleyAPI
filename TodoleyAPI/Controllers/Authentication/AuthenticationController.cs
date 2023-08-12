using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoleyAPI.DTO;
using TodoleyAPI.Models;
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;

namespace TodoleyAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly TodoleyDbContext _db;
        public AccountController(IConfiguration configuration, TodoleyDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserDTO input)
        {
            user.Email = input.Email;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(input.Password);
            user.PasswordHash = passwordHash;
            List<User> users = new List<User>();
            if(users.IsNullOrEmpty())
            {
                user.ID = 1;
            }
            else
            {
                var lastUser = users.Last();
                user.ID = lastUser.ID + 1;
            }
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }
    
        [HttpPost]
        public ActionResult<User> Login(UserDTO request)
        {
            var user = _db.Users.Where(x=>x.Email == request.Email).FirstOrDefault();
            if (user == null)
            {
                return NotFound("This record does not exist");
            }
            if(!BCrypt.Net.BCrypt.Verify(request.Password,user.PasswordHash))
            {
                return BadRequest("Wrong password");
            }
            var token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
 }