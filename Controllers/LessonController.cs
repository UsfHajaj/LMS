using AutoMapper;
using LMS.DTOs;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;
        private readonly IMapper _mapper;

        public LessonController(ILessonService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("course/{courseId}/module/{moduleId}")]
        public async Task<IActionResult> GetLessonsByModuleId(int courseId, int moduleId)
        {
            var lessons = await _service.GetLessonsByModuleId(courseId, moduleId);
            if (lessons == null || !lessons.Any())
            {
                return NotFound(new { Message = "No lessons found for the specified module." });
            }
            return Ok(lessons);
        }
        [HttpGet("{lessonId}")]
        public async Task<IActionResult> GetLessonById(int lessonId)
        {
            var lesson = await _service.GetLessonById(lessonId);
            if (lesson == null)
            {
                return NotFound(new { Message = "Lesson not found." });
            }
            return Ok(lesson);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromBody] EditLessonDto lessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (lessonDto == null)
            {
                return BadRequest(new { Message = "Invalid lesson data." });
            }
            var createdLesson = await _service.CreateLesson(lessonDto);
            return CreatedAtAction(nameof(GetLessonById), new { lessonId = createdLesson.Id }, createdLesson);
        }
        [HttpPut("{lessonId}")]
        public async Task<IActionResult> UpdateLesson(int lessonId, [FromBody] EditLessonDto lessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (lessonDto == null)
            {
                return BadRequest(new { Message = "Invalid lesson data." });
            }
            await _service.UpdateLesson(lessonId, lessonDto);
            return NoContent();
        }
        [HttpDelete("{lessonId}")]
        public async Task<IActionResult> DeleteLesson(int lessonId)
        {
            var lesson = await _service.GetLessonById(lessonId);
            if (lesson == null)
            {
                return NotFound(new { Message = "Lesson not found." });
            }
            await _service.DeleteLesson(lessonId);
            return NoContent();
        }
    }
}
