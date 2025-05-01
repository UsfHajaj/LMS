using LMS.Models.Context;
using LMS.Repositories.Interfaces;

namespace LMS.Repositories.Implementions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IQuizzeRepository QuizRepository { get; private set; }
        public IQuestionRepository QuestionRepository { get; private set; }
        public IAnswerRepository AnswerRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            QuizRepository = new QuizzeRepository(_context);
            QuestionRepository = new QuestionRepository(_context);
            AnswerRepository = new AnswerRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
