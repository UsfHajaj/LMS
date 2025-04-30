using AutoMapper;
using LMS.DTOs;
using LMS.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public InstructorController(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] InstructorRegisterDto model)
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
            var user = _mapper.Map<Instructor>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Instructor");
                return Ok(new { Message = "User registered successfully" });
            }
            return BadRequest(result.Errors);
        }


        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var instructor = await _userManager.GetUserAsync(User);
            var profile =_mapper.Map<InstructorDto>(instructor);
            return Ok(profile);
        }
        [HttpPut("profile")]
        public async Task<IActionResult> PutProfile([FromBody] EditInstructorDto profileDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            if (user is not Instructor instructor)
            {
                return BadRequest("User is not an instructor.");
            }
            _mapper.Map(profileDto, instructor);
            var result = await _userManager.UpdateAsync(instructor);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Profile updated successfully" });
            }
            return BadRequest(result.Errors);
        }
    }
}
