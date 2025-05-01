using LMS.Models.Context;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class QuizzeRepository : GenericRepository<Quiz>,IQuizzeRepository
    {
        public QuizzeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Quiz> GetQuizWithQuestionsAndAnswersAsync(int quizId)
        {
            return await _dbSet
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == quizId);
        }

        public async Task<IEnumerable<Quiz>> GetQuizzesByModuleIdAsync(int moduleId)
        {
            return await _dbSet
                .Where(q => q.ModuleId == moduleId)
                .ToListAsync();
        }
    }
}
