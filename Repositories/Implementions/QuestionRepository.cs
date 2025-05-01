using LMS.Models.Context;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Question>> GetQuestionsByQuizIdAsync(int quizId)
        {
            return await _dbSet
                .Where(q => q.QuizId == quizId)
                .Include(q => q.Answers)
                .ToListAsync();
        }
    }
}
