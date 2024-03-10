using backend.Data;
using backend.Models;
using backend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _context;

        public CourseService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCourse(int courseId, Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(courseId);
            if (existingCourse == null)
            {
                return false;
            }

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;

            _context.Courses.Update(existingCourse);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCourse(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
            {
                return false;
            }

            _context.Courses.Remove(course);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Course> GetCourseById(int couseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == couseId);
        }
    }
}
