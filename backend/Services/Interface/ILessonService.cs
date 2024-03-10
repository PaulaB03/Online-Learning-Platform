using backend.Models;

namespace backend.Services.Interface
{
    public interface ILessonService
    {
        Task<bool> AddLesson(Lesson lesson);
        Task<bool> UpdateLesson(int lessonId, Lesson lesson);
        Task<bool> DeleteLesson(int lessonId);
        Task<Lesson> GetLessonById(int lessonId);
        Task<string> GetLessonName(int lessonId);
    }
}
