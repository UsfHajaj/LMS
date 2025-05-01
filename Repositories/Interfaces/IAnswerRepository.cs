using LMS.Models.Interaction;

namespace LMS.Repositories.Interfaces
{
    public interface IAnswerRepository:IGenericRepository<Answer>
    {
        Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(int questionId);
    }
}
