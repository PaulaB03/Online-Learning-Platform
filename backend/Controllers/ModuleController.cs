using backend.Models;
using backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> AddModule(Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _moduleService.AddModule(module);
            if (result)
            {
                return Ok("Module added successfully.");
            }
            else
            {
                return BadRequest("Failed to add the module.");
            }
        }

        [HttpPut("{moduleId}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> UpdateModule(int moduleId, Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _moduleService.UpdateModule(moduleId, module);
            if (result)
            {
                return Ok("Module updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update module.");
            }
        }

        [HttpDelete("{moduleId}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> DeleteModule(int moduleId)
        {
            var result = await _moduleService.DeleteModule(moduleId);
            if (result)
            {
                return Ok("Module deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete module.");
            }
        }

        [HttpGet("{moduleId}")]
        [Authorize]
        public async Task<IActionResult> GetModuleById(int moduleId)
        {
            var module = await _moduleService.GetModuleById(moduleId);
            if (module == null)
            {
                return NotFound($"Module with id {moduleId} not found!");
            }
            else
            {
                return Ok(module);
            }
        }

        [HttpGet("/Module/{moduleId}")]
        public async Task<IActionResult> GetModuleName(int moduleId)
        {
            try
            {
                var module = await _moduleService.GetModuleName(moduleId);
                return Ok(module);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
