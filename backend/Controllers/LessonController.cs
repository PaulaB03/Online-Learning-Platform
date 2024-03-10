using backend.Models;
using backend.Services;
using backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> AddLesson(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _lessonService.AddLesson(lesson);
            if (result)
            {
                return Ok("Lesson added successfully.");
            }
            else
            {
                return BadRequest("Failed to add the lesson.");
            }
        }

        [HttpPut("{lessonId}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> UpdateLesson(int lessonId, Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _lessonService.UpdateLesson(lessonId, lesson);   
            if (result)
            {
                return Ok("Lesson updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update lesson.");
            }
        }

        [HttpDelete("{lessonId}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> DeleteLesson(int lessonId)
        {
            var result = await _lessonService.DeleteLesson(lessonId);
            if (result)
            {
                return Ok("Lesson deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete lesson.");
            }
        }

        [HttpGet("{lessonId}")]
        [Authorize]
        public async Task<IActionResult> GetLessonById(int lessonId)
        {
            var lesson = await _lessonService.GetLessonById(lessonId);
            if (lesson == null)
            {
                return NotFound($"Lesson with id {lessonId} not found!");
            }
            else
            {
                return Ok(lesson);
            }
        }

        [HttpGet("/Lesson/{lessonId}")]
        public async Task<IActionResult> GetLessonName(int lessonId)
        {
            try
            {
                var lesson = await _lessonService.GetLessonName(lessonId);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
