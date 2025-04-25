using AutoMapper;
using LMS.DTOs;
using LMS.Models.Context;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoursesServies _servies;
        private readonly IMapper _mapper;

        public CoursesController(ApplicationDbContext context, ICoursesServies servies, IMapper mapper)
        {
            _context = context;
            _servies = servies;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var courses = await _servies.GetAllCoursesAsync();
            if (courses == null)
            {
                return NotFound("No courses found.");
            }
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _servies.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseCreateDto coursedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (coursedto == null)
            {
                return BadRequest("Course data is null.");
            }
            var Createdcourses = await _servies.AddCourseAsync(coursedto);
            var courses = _mapper.Map<CourseDto>(Createdcourses);

            return CreatedAtAction(nameof(GetCourseById), new { id = courses.Id }, courses);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseUpdateDto coursedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (coursedto == null)
            {
                return BadRequest("Course data is null.");
            }
            var course = await _servies.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }
            await _servies.UpdateCourseAsync(id, coursedto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _servies.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }
            await _servies.DeleteCourseAsync(id);
            return NoContent();
        }
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCoursesWithCategoryId(int id)
        {
            var courses = await _servies.GetCoursesWithCategoryIdAsync(id);
            if (courses == null)
            {
                return NotFound($"No courses found for category ID {id}.");
            }
            return Ok(courses);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchCourses([FromQuery] string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return BadRequest("Search term cannot be null or empty.");
            }
            var courses = await _servies
                .FindCoursesAsync(c => c.Title.Contains(searchTerm)
                ||c.Description.Contains(searchTerm));
            if (courses == null || !courses.Any())
            {
                return NotFound($"No courses found matching the search term '{searchTerm}'.");
            }
            return Ok(courses);
        }
        [HttpGet("featured")]
        public async Task<IActionResult> GetFeaturedCourses()
        {
            var courses = await _servies
                .FindCoursesAsync(c => c.IsFeatured);
            if (courses == null || !courses.Any())
            {
                return NotFound("No featured courses found.");
            }
            return Ok(courses);
        }
    }
}
