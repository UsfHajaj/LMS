using LMS.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.DTOs
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
            var profile = new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.ProfilePicture,
                user.Bio
            };
            return Ok(profile);
        }
        [HttpPut("profile")]
        public async Task<IActionResult> PutProfile([FromBody] UpdateProfileDto profileDto)
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
            user.FirstName = profileDto.FirstName;
            user.LastName = profileDto.LastName;
            user.ProfilePicture = profileDto.ProfilePicture;
            user.Bio = profileDto.Bio;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Profile updated successfully" });
            }
            return BadRequest(result.Errors);
        }
        [HttpDelete("profile")]
        public async Task<IActionResult> DeleteProfile()
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
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Profile deleted successfully" });
            }
            return BadRequest(result.Errors);
        }
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetProfileById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var profile = new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.ProfilePicture,
                user.Bio
            };
            return Ok(profile);
        }
    }
}
