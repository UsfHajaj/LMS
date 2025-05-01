using AutoMapper;
using LMS.DTOs;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var resul=await _service.GetAllPaymentsAsync();
            if(resul==null)
                return NotFound();
            return Ok(resul);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentByID(int id)
        {
            var result = await _service.GetPaymentById(id);
            if(result==null) return NotFound();
            return Ok(result);
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPaymentsByUserId(string userId)
        {
            var result = await _service.GetAllPaymentsByUserIdAsync(userId);
            if(result==null) return NotFound();
            return Ok(result);
        }
        [HttpGet("courses/{courseId}")]
        public async Task<IActionResult> GetPaymentByCourseId(int courseId)
        {
            var result=await _service.GetAllPaymentsBycourseIdAsync(courseId);
            if(result==null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostPayment([FromBody] CreatePaymentDto paymentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result=await _service.CreatePayment(paymentDto);

            return CreatedAtAction(nameof(GetPaymentByID), new { id = result.Id }, result);
        }
    }
}
