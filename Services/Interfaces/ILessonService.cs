using LMS.DTOs;

namespace LMS.Services.Interfaces
{
    public interface ILessonService
    {
        Task<LessonDto> GetLessonById(int lessonId);
        Task<IEnumerable<LessonDto>> GetLessonsByModuleId(int courseId,int moduleId);
        Task<LessonDto> CreateLesson(EditLessonDto lessonDto);
        Task UpdateLesson(int lessonId, EditLessonDto lessonDto);
        Task DeleteLesson(int lessonId);
    }
}
