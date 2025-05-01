using LMS.Models.Context;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class ProgressRepository : GenericRepository<Progress>, IProgressRepository
    {
        public ProgressRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Progress> GetProgressByCourseIdAndLessonId(int courseId, int lessonId)
        {
            return await _dbSet
                .Include(p => p.Student)
                .Include(p => p.Enrollment)
                .Include(p => p.Lesson)
                .FirstOrDefaultAsync(m=>m.Lesson.Module.CourseId==courseId&&m.LessonId==lessonId);
        }

        public async Task<IEnumerable<Progress>> GetProgressByCourseIdAsync(int courseId)
        {
            return await _dbSet
                .Include(p => p.Student)
                .Include(p => p.Enrollment)
                .Include(p => p.Lesson)
                .Where(p => p.Lesson.Module.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Progress>> GetProgressByUserIdAsync(string userId)
        {
            return await _dbSet
                .Include(p => p.Student)
                .Include(p => p.Enrollment)
                .Include(p => p.Lesson)
                .Where(p => p.StudentId == userId)
                .ToListAsync();
        }
    }
}
