using FunDooNotes_App.WebAPI.Models;
using FunDooNotes_App.BLL.Interfaces;
using FunDooNotes_App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FunDooNotes_App.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email
                };

                var registeredUser = await _userService.RegisterAsync(user, request.Password);
                return Ok(new { message = "Registration successful", userId = registeredUser.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.LoginAsync(request.Email, request.Password);
            if (user == null)
                return Unauthorized(new { error = "Invalid credentials" });

            // Aap yahan JWT token generation ka code bhi add kar sakte hain.
            return Ok(new { message = "Login successful", userId = user.Id });
        }
    }
}
