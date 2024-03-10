using backend.Data;
using backend.Models;
using backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> AddCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.AddCourse(course);
            if (result)
            {
                return Ok("Course added successfully.");
            }
            else
            {
                return BadRequest("Failed to add the course.");
            }
        }

        [HttpPut("{courseId}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> UpdateCourse(int courseId, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.UpdateCourse(courseId, course);
            if (result)
            {
                return Ok("Course updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update course.");
            }
        }

        [HttpDelete("{courseId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var result = await _courseService.DeleteCourse(courseId);
            if (result)
            {
                return Ok("Course deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete course.");
            }
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var course = await _courseService.GetCourseById(courseId);
            if (course == null)
            {
                return NotFound($"Course with id {courseId} not found!");
            }
            else
            {
                return Ok(course);
            }
        }
    }
}
