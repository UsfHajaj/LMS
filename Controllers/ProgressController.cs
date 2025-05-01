using AutoMapper;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        //[HttpPost("courses/{courseId}/lessons/{lessonId}/complete")]
        //public IActionResult PostProgressCommplete()
        //{

        //}


    }
}
