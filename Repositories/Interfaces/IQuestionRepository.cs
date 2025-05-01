using LMS.Models.Interaction;

namespace LMS.Repositories.Interfaces
{
    public interface IQuestionRepository:IGenericRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestionsByQuizIdAsync(int quizId);
    }
}
