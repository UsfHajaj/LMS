using AutoMapper;
using LMS.DTOs;
using LMS.Services.Implement;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizeServies _servies;
        private readonly IMapper _mapper;

        public QuizController(IQuizeServies servies,IMapper mapper)
        {
            _servies = servies;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizDto>>> GetQuizzes(int courseId, int moduleId)
        {
            try
            {
                var quizzes = await _servies.GetQuizzesByModuleIdAsync(courseId, moduleId);
                return Ok(quizzes);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}/results")]
        public async Task<ActionResult<QuizResultDto>> GetQuizResults(int courseId, int moduleId, int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var quize = await _servies.GetQuizResultsAsync(courseId, moduleId, id, userId);
            return Ok(quize);
        }

        [HttpPost]
        public async Task<IActionResult> PostQuize(int courseId, int moduleId, CreateQuizDto createQuizDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _servies.CreateQuizAsync(courseId, moduleId, createQuizDto, UserId);
            return CreatedAtAction(nameof(GetQuiz), new { courseId, moduleId, id = result.Id }, result);
        }

        [HttpPost("{id}/submit")]
        public async Task<ActionResult<QuizResultDto>> SubmitQuiz(int courseId, int moduleId, int id, [FromBody] List<QuizSubmissionDto> submissions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _servies.SubmitQuizAsync(courseId, moduleId,id, submissions, userId);
            return Ok(result);
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuiz(int courseId, int moduleId, int id)
        {
            try
            {
                var instructorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await _servies.DeleteQuizAsync(courseId, moduleId, id, instructorId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizDetailDto>> GetQuiz(int courseId, int moduleId, int id)
        {
            try
            {
                var quiz = await _servies.GetQuizByIdAsync(courseId, moduleId, id);
                return Ok(quiz);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<QuizDetailDto>> UpdateQuiz(int courseId, int moduleId, int id, [FromBody] UpdateQuizDto updateQuizDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var instructorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var quiz = await _servies.UpdateQuizAsync(courseId, moduleId, id, updateQuizDto, instructorId);
            return Ok(quiz);
        }
    }
}
