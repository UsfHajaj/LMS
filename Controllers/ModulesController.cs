using AutoMapper;
using LMS.DTOs;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModulesService _service;
        private readonly IMapper _mapper;

        public ModulesController(IModulesService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllModules()
        {
            var modules = await _service.GetAllModulesAsync();
            if (modules == null || !modules.Any())
            {
                return NotFound();
            }
            return Ok(modules);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModulesById(int id)
        {
            var module = await _service.GetModulesByIdAsync(id);
            if (module == null)
            {
                return NotFound();
            }
            return Ok(module);
        }
        [HttpPost]
        public async Task<IActionResult> AddModules([FromBody] EditModulesDto modulesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            if (modulesDto == null)
            {
                return BadRequest("Invalid data.");
            }
            var module = await _service.AddModulesAsync(modulesDto);
            return CreatedAtAction(nameof(GetModulesById), new { id = module.Id }, module);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModules(int id, [FromBody] EditModulesDto moduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (moduleDto == null)
            {
                return BadRequest("Invalid data.");
            }
            var existingModule = await _service.GetModulesByIdAsync(id);
            if (existingModule == null)
            {
                return NotFound();
            }
            await _service.UpdateModulesAsync(id, moduleDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModules(int id)
        {
            var existingModule = await _service.GetModulesByIdAsync(id);
            if (existingModule == null)
            {
                return NotFound();
            }
            await _service.DeleteModulesAsync(id);
            return NoContent();
        }

    }
}
