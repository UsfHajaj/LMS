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
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNotification()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notification = await _service.GetUserNotificationsAsync(userId);
            if(notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.MarkAsReadAsync(id, userId);
            return NoContent();
        }
        [HttpPut("read-all")]
        public async Task<IActionResult> PutNotificationReadAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.MarkAllAsReadAsync(userId);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.DeleteAsync(id, userId);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostNotification([FromBody]CreateNotificationDto notificationDto)
        {
            var result = await _service.CreateNotificationAsync(notificationDto);
            if(result == null) { return NoContent(); }
            return CreatedAtAction(nameof(GetAllNotification), new { id = result.Id }, result);
        }
    }
}
