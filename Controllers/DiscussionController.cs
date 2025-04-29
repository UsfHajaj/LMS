using AutoMapper;
using LMS.DTOs;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussionController : ControllerBase
    {
        private readonly IDiscussionServices _services;
        private readonly IMapper _mapper;

        public DiscussionController(IDiscussionServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiscussion()
        {
            var discussions = await _services.GetAllDiscussionsAsync();
            return Ok(discussions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscussionById(int id)
        {
            var discussion = await _services.GetDiscussionByIdAsync(id);
            if (discussion == null)
            {
                return NotFound();
            }
            return Ok(discussion);
        }
        [HttpGet("course/{courseId}/discussion/{discussionId}/comments")]
        public async Task<IActionResult> GetAllCommentByCourseIdDiscussionID(int courseId, int discussionId)
        {
            var comments = await _services.GetAllCommentByCourseIdDiscussionIDAsync(discussionId, courseId);
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);
        }
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetDiscussionsByCourseId(int courseId)
        {
            var discussions = await _services.GetDiscussionsByCourseIdAsync(courseId);
            if (discussions == null)
            {
                return NotFound();
            }
            return Ok(discussions);
        }
        [HttpGet("course/{courseId}/user/{userId}")]
        public async Task<IActionResult> GetDiscussionsByCourseIdAndUserId(int courseId, string userId)
        {
            var discussions = await _services.GetDiscussionsByCourseIdAndUserIdAsync(courseId, userId);
            if (discussions == null)
            {
                return NotFound();
            }
            return Ok(discussions);
        }

        [HttpPost("discussion")]
        public async Task<IActionResult> AddDiscussion([FromBody] EditDiscussionDto discussion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();
            if (discussion == null)
            {
                return BadRequest();
            }
            var newDiscussion = await _services.AddDiscussionAsync(discussion,userId);
            return CreatedAtAction(nameof(GetDiscussionById), new { id = newDiscussion.Id }, newDiscussion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscussion(int id, [FromBody] EditDiscussionDto discussion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (discussion == null)
            {
                return BadRequest();
            }
            await _services.UpdateDiscussionAsync(id, discussion);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscussion(int id)
        {
            var discussion = await _services.GetDiscussionByIdAsync(id);
            if (discussion == null)
            {
                return NotFound();
            }
            await _services.DeleteDiscussionAsync(id);
            return NoContent();
        }
        [HttpPost("course/{courseId}/discussion/{discussionId}/comments")]
        public async Task<IActionResult> AddComment([FromBody] EditCommentDto comment ,int courseId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            var discussion = await _services.GetDiscussionsByCourseIdAndUserIdAsync(courseId,userId);
            var discussionId= discussion.FirstOrDefault()!.Id;
            if (comment == null)
            {
                return BadRequest();
            }
            
            var newComment = await _services.AddCommentAsync(comment, discussionId, courseId,userId);
            return CreatedAtAction(nameof(GetAllCommentByCourseIdDiscussionID), new { courseId = courseId, discussionId = discussionId }, newComment);

        }
    }
}
