using LMS.DTOs;
using LMS.Models.Interaction;

namespace LMS.Repositories.Interfaces
{
    public interface IQuizzeRepository:IGenericRepository<Quiz>
    {
        Task<IEnumerable<Quiz>> GetQuizzesByModuleIdAsync(int moduleId);
        Task<Quiz> GetQuizWithQuestionsAndAnswersAsync(int quizId);
    }
}
