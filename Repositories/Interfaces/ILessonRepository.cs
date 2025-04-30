using LMS.Models.Courses;

namespace LMS.Repositories.Interfaces
{
    public interface ILessonRepository:IGenericRepository<Lesson>
    {
        Task<IEnumerable<Lesson>> GetLessonsByModuleId(int courseID,int moduleId);
        Task<Lesson> GetLessonWithDetails(int lessonId);
    }
}
