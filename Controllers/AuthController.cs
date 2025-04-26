using AutoMapper;
using LMS.DTOs;
using LMS.Models.Auth;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public AuthController(UserManager<AppUser> userManager, IMapper mapper, IJwtService jwtService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] StudentRegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest("Email already in use");
            }
            var user = _mapper.Map<Student>(model);
            user.UserName = model.UserName ?? model.Email;
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {

                await _userManager.AddToRoleAsync(user, "Student");
                return Ok(new { Message = "User registered successfully" });
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
            {
                var token = _jwtService.GenerateJwtToken(user);
                return Ok(new
                {
                    token = token,
                    expiration = DateTime.UtcNow.AddDays(1),
                });
            }

            return Unauthorized("Invalid email or password");
        }

        //[HttpPost("forgot-password")]
        //public async Task<IActionResult> forgotPassword([FromBody] ForgotPasswordDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var user =await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        return BadRequest("User not found");
        //    }
        //    var token =await _userManager.GeneratePasswordResetTokenAsync(user);

        //    await _emailService.SendAsync(model.Email,$"Your Reset token", $"Your Reset token is {token}");
        //    // Implement password reset logic here
        //    return Ok("Password reset link sent to your email");
        //}

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }
        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            var result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password changed successfully");
            }
            return BadRequest(result.Errors);
        }
    }
}
