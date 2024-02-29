using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Login user)
        {
            if (await _authService.Register(user))
            {
                return Ok("User created");
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login user)
        {
            if (await _authService.Login(user))
            {
                var tokenString = await _authService.GenerateTokenString(user);
                return Ok(tokenString);
            }

            return BadRequest();
        }

        [HttpPost("AssignRole/{email}/{newRole}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(string email, string newRole)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Invalid email.");
            }

            if (string.IsNullOrEmpty(newRole))
            {
                return BadRequest("Invalid role.");
            }

            var result = await _authService.AssignRole(email, newRole);
            if (result)
            {
                return Ok($"Role {newRole} assigned to {email} successfully.");
            }
            return BadRequest("Failed to assign role.");
        }

        [HttpDelete("RemoveRole/{email}/{role}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRole(string email, string role)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Invalid email.");
            }

            if (string.IsNullOrEmpty(role))
            {
                return BadRequest("Invalid role.");
            }

            // Prevent removing the "user" role
            if (role.Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Cannot remove the 'User' role.");
            }

            var result = await _authService.RemoveRole(email, role);
            if (result)
            {
                return Ok($"Role {role} removed from {email} successfully.");
            }
            return BadRequest("Failed to remove role.");
        }
    }
}
