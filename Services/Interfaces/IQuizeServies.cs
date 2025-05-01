using LMS.DTOs;

namespace LMS.Services.Interfaces
{
    public interface IQuizeServies
    {
        Task<IEnumerable<QuizDto>> GetQuizzesByModuleIdAsync(int courseId, int moduleId);
        Task<QuizDetailDto> GetQuizByIdAsync(int courseId, int moduleId, int quizId);
        Task<QuizDetailDto> CreateQuizAsync(int courseId, int moduleId, CreateQuizDto createQuizDto, string instructorId);
        Task<QuizDetailDto> UpdateQuizAsync(int courseId, int moduleId, int quizId, UpdateQuizDto updateQuizDto, string instructorId);
        Task DeleteQuizAsync(int courseId, int moduleId, int quizId, string instructorId);
        Task<QuizResultDto> SubmitQuizAsync(int courseId, int moduleId, int quizId, List<QuizSubmissionDto> submissions, string studentId);
        Task<QuizResultDto> GetQuizResultsAsync(int courseId, int moduleId, int quizId, string studentId);

    }
}
