using LMS.Models.Context;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _dbSet
                .Where(m => m.QuestionId == questionId)
                .ToListAsync();
        }
    }
}
