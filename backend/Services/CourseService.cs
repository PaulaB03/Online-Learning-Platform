using backend.Data;
using backend.Models;

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
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
