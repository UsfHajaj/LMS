using AutoMapper;
using LMS.DTOs;
using LMS.Models.Interaction;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressServies _servies;
        private readonly IMapper _mapper;

        public ProgressController(IProgressServies servies,IMapper mapper)
        {
            _servies = servies;
            _mapper = mapper;
        }
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetProgressByCourseId(int courseId)
        {
            var progress = await _servies.GetProgressByCourseIdAsync(courseId);
            if (progress == null || !progress.Any())
            {
                return NotFound("No progress found for this course.");
            }
            return Ok(progress);
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetProgressByUserId(string userId)
        {
            var progress = await _servies.GetProgressByUserIdAsync(userId);
            if (progress == null || !progress.Any())
            {
                return NotFound("No progress found for this user.");
            }
            return Ok(progress);
        }
        [HttpGet("courses/{courseId}/lessons/{lessonId}")]
        public async Task<IActionResult> GetProgressByCourseIdLessonIdComplete(int courseId,int lessonId)
        {
            var progress=await _servies.GetProgressByCourseIdAndLessonIdAsync(courseId, lessonId);
            if (progress == null)
            {
                return NotFound();
            }
            return Ok(progress);
        }
        [HttpPost("courses/{courseId}/lessons/{lessonId}/complete")]
        public async Task<ActionResult<ProgressDto>> PostProgressCommplete(int courseId,int lessonId,[FromBody] EditProgressDto progressDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            progressDto.LessonId = lessonId;
            var Newprogress=await _servies.AddProgressAsync(userId,true, progressDto);
            var progress=_mapper.Map<ProgressDto>(Newprogress);
            return Newprogress;
        }
        [HttpPost("courses/{courseId}/lessons/{lessonId}/Start")]
        public async Task<ActionResult<ProgressDto>> PostProgressStart(int courseId, int lessonId, [FromBody] EditProgressDto progressDto)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            progressDto.LessonId = lessonId;
            var Newprogress = await _servies.AddProgressAsync(userId, false, progressDto);
            var progress = _mapper.Map<ProgressDto>(Newprogress);
            return Newprogress;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgress(int id, [FromBody] UpdateProgressDto progressDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existProgress= await _servies.GetProgressByIdAsync(id);
            if(existProgress==null)
                return NotFound();
            await _servies.UpdateProgressAsync(id,userId, progressDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProgress(int id)
        {
            var progress = await _servies.GetProgressByIdAsync(id);
            if(progress==null) return NotFound();
            await _servies.DeleteProgressAsync(id);
            return NoContent();
        }

    }
}
