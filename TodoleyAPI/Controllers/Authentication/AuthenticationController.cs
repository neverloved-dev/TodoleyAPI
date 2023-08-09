using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoleyAPI.DTO;
using TodoleyAPI.Models;
using System.Linq.Expressions;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity; 
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims;
using System.Diagnostics.Eventing.Reader;

namespace TodoleyAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TodoleyDbContext _context;
        private readonly ILogger<TodoItemsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApiUser> _userManager; 
        private readonly SignInManager<ApiUser> _signInManager; 
     public AccountController( TodoleyDbContext context, ILogger<TodoItemsController> logger, IConfiguration configuration, UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [ResponseCache(CacheProfileName = "NoCache")]
        public async Task<ActionResult> Register(RegisterDTO input)
        {
            if (input == null || _userManager == null)
            {
                return StatusCode(500, "Internal server error");
            }

            if (ModelState.IsValid)
            {
                var newUser = new ApiUser();
                newUser.UserName = input.UserName;
                newUser.Email = input.Email;

                var result = await _userManager.CreateAsync(newUser, input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User {userName} ({email}) has been created.", newUser.UserName, newUser.Email);
                    return StatusCode(201, $"User '{newUser.UserName}' has been created.");
                }
                else
                {
                    var errors = result.Errors.Select(error => error.Description);
                    _logger.LogError("User creation failed: {errors}", string.Join(", ", errors));

                    var details = new ValidationProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "User creation failed due to validation errors.",
                    };
                    return BadRequest(details);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    
        [HttpPost]
        [ResponseCache(CacheProfileName = "NoCache")]
        public async Task<ActionResult> Login()
        {
            throw new NotImplementedException();
        }
    }
 }