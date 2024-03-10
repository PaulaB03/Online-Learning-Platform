using backend.Data;
using backend.Models;
using backend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class LessonService : ILessonService
    {
        private readonly DataContext _context;

        public LessonService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateLesson(int lessonId, Lesson lesson)
        {
            var existingLesson = await _context.Lessons.FindAsync(lessonId);
            if (existingLesson == null)
            {
                return false;
            }

            existingLesson.Name = lesson.Name;
            existingLesson.Content = lesson.Content;

            _context.Lessons.Update(existingLesson);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLesson(int lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            if (lesson == null)
            {
                return false;
            }

            _context.Lessons.Remove(lesson);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Lesson> GetLessonById(int lessonId)
        {
            return await _context.Lessons.FirstOrDefaultAsync(l => l.LessonId == lessonId);
        }

        public async Task<string> GetLessonName(int lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            if (lesson == null)
            {
                throw new Exception("Couldn't find lesson");
            }

            return lesson.Name;
        }
    }
}
