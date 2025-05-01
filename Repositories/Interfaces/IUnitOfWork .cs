namespace LMS.Repositories.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IQuizzeRepository QuizRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; }

        Task<int> CompleteAsync();
    }
}
