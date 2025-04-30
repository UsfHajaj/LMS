using LMS.Models.Context;
using LMS.Models.Courses;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByModuleId(int courseId, int moduleId)
        {
            var lessons =await _dbSet
                .Include(l => l.Module)
                .Where(l => l.ModuleId == moduleId&&l.Module.Course.Id==courseId)
                .Include(l => l.Attachments)
                .Include(l => l.ProgressRecords)
                .ToListAsync();
            return lessons;
        }

        public async Task<Lesson> GetLessonWithDetails(int lessonId)
        {
            return await _dbSet
                .Include(l => l.Module)
                .Include(l => l.Attachments)
                .Include(l => l.ProgressRecords)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
        }
    }
}
