using backend.Models;

namespace backend.Services
{
    public interface ICourseService
    {
        Task<bool> AddCourse(Course course);
    }
}
