using LMS.Models.Interaction;

namespace LMS.Repositories.Interfaces
{
    public interface IProgressRepository:IGenericRepository<Progress>
    {
        Task<IEnumerable<Progress>> GetProgressByCourseIdAsync(int courseId);
        Task<IEnumerable<Progress>> GetProgressByUserIdAsync(string userId);
        Task<Progress> GetProgressByCourseIdAndLessonId(int courseId, int lessonId);


    }
}
