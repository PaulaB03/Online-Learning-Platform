using backend.Models;

namespace backend.Services.Interface
{
    public interface ICourseService
    {
        Task<bool> AddCourse(Course course);
        Task<bool> UpdateCourse(int courseId, Course course);
        Task<bool> DeleteCourse(int courseId);
        Task<Course> GetCourseById(int courseId);
    }
}
