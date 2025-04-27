using LMS.DTOs;
using LMS.Models.Interaction;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentsServices _services;

        public EnrollmentsController(IEnrollmentsServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var enrollments = await _services.GetAllEnrollmentsAsync();
            if (enrollments == null)
            {
                return NotFound();
            }
            return Ok(enrollments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _services.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }
        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetEnrollmentsByStudentId(string studentId)
        {
            var enrollments = await _services.GetEnrollmentsByStudentIdAsync(studentId);
            if (enrollments == null)
            {
                return NotFound();
            }
            return Ok(enrollments);
        }
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetEnrollmentsByCourseId(int courseId)
        {
            var enrollments = await _services.GetEnrollmentsByCourseIdAsync(courseId);
            if (enrollments == null)
            {
                return NotFound();
            }
            return Ok(enrollments);
        }
        [HttpGet("student/{studentId}/course/{courseId}")]
        public async Task<IActionResult> GetEnrollmentByStudentIdAndCourseId(string studentId, int courseId)
        {
            var enrollment = await _services.GetEnrollmentByStudentIdAndCourseIdAsync(studentId, courseId);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }
        [HttpPost]
        public async Task<IActionResult> AddEnrollment([FromBody] UpdateEnrollmentDto enrollmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (enrollmentDto == null)
            {
                return BadRequest();
            }
            var result = await _services.AddEnrollmentAsync(enrollmentDto);

            return CreatedAtAction(nameof(GetEnrollmentById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, [FromBody] UpdateEnrollmentDto enrollmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _services.UpdateEnrollmentAsync(id,enrollmentDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _services.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            await _services.DeleteEnrollmentAsync(id);
            return NoContent();
        }
    }
}
