using LMS.DTOs;

namespace LMS.Services.Interfaces
{
    public interface IProgressServies
    {
        Task<IEnumerable<ProgressDto>> GetProgressByCourseIdAsync(int courseId);
        Task<IEnumerable<ProgressDto>> GetProgressByUserIdAsync(string userId);
        Task<ProgressDto> GetProgressByIdAsync(int id);
        Task<ProgressDto> GetProgressByCourseIdAndLessonIdAsync(int courseId, int lessonId);
        Task<ProgressDto> AddProgressAsync(string studentId,bool IsCompleted, EditProgressDto progress);
        Task UpdateProgressAsync(int id, string studentId, bool IsCompleted, EditProgressDto progress);
        Task DeleteProgressAsync(int id);
    }
}
