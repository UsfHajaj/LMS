using AutoMapper;
using LMS.DTOs;
using LMS.Models.Courses;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;

namespace LMS.Services.Implement
{
    public class QuizService:IQuizeServies
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuizService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QuizDto>> GetQuizzesByModuleIdAsync(int courseId, int moduleId)
        {
            var quizes = await _unitOfWork.QuizRepository.GetQuizzesByModuleIdAsync(moduleId);
            return _mapper.Map<IEnumerable<QuizDto>>(quizes);
        }
        public async Task<QuizDetailDto> GetQuizByIdAsync(int courseId, int moduleId, int quizId)
        {
            
            var quize= await _unitOfWork.QuizRepository.GetQuizWithQuestionsAndAnswersAsync(quizId);
            return _mapper.Map<QuizDetailDto>(quize);
        }
        public async Task<QuizDetailDto> CreateQuizAsync(int courseId, int moduleId, CreateQuizDto createQuizDto, string instructorId)
        {
            var quiz = _mapper.Map<Quiz>(createQuizDto);
            quiz.ModuleId = moduleId;

            await _unitOfWork.QuizRepository.AddAsync(quiz);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<QuizDetailDto>(quiz);
        }
        public async Task<QuizDetailDto> UpdateQuizAsync(int courseId, int moduleId, int quizId, UpdateQuizDto updateQuizDto, string instructorId)
        {
            var quiz = await _unitOfWork.QuizRepository.GetQuizWithQuestionsAndAnswersAsync(quizId);
            if (quiz == null || quiz.ModuleId != moduleId)
                throw new KeyNotFoundException($"Quiz with id {quizId} not found in module {moduleId}");
            // Update quiz properties
            quiz.Title = updateQuizDto.Title;
            quiz.Description = updateQuizDto.Description;
            quiz.TimeLimit = updateQuizDto.TimeLimit;
            quiz.PassingScore = updateQuizDto.PassingScore;
            quiz.IsActive = updateQuizDto.IsActive;


            // Handle questions and answers updates
            if (updateQuizDto.Questions != null)
            {
                // Get existing questions
                var existingQuestions = quiz.Questions.ToList();
                var updatedQuestionIds = updateQuizDto.Questions
                    .Where(q => q.Id.HasValue)
                    .Select(q => q.Id.Value)
                    .ToList();

                // Remove questions not in the update DTO
                foreach (var question in existingQuestions)
                {
                    if (!updatedQuestionIds.Contains(question.Id))
                    {
                        _unitOfWork.QuestionRepository.DeleteAsync(question);
                    }
                }

                // Update or add questions
                foreach (var questionDto in updateQuizDto.Questions)
                {
                    if (questionDto.Id.HasValue)
                    {
                        // Update existing question
                        var existingQuestion = existingQuestions.FirstOrDefault(q => q.Id == questionDto.Id.Value);
                        if (existingQuestion != null)
                        {
                            existingQuestion.QuestionText = questionDto.QuestionText;
                            existingQuestion.QuestionType = questionDto.QuestionType;
                            existingQuestion.Points = questionDto.Points;

                            // Handle answers
                            if (questionDto.Answers != null)
                            {
                                var existingAnswers = existingQuestion.Answers.ToList();
                                var updatedAnswerIds = questionDto.Answers
                                    .Where(a => a.Id.HasValue)
                                    .Select(a => a.Id.Value)
                                    .ToList();

                                // Remove answers not in the update DTO
                                foreach (var answer in existingAnswers)
                                {
                                    if (!updatedAnswerIds.Contains(answer.Id))
                                    {
                                        _unitOfWork.AnswerRepository.DeleteAsync(answer);
                                    }
                                }

                                // Update or add answers
                                foreach (var answerDto in questionDto.Answers)
                                {
                                    if (answerDto.Id.HasValue)
                                    {
                                        // Update existing answer
                                        var existingAnswer = existingAnswers.FirstOrDefault(a => a.Id == answerDto.Id.Value);
                                        if (existingAnswer != null)
                                        {
                                            existingAnswer.AnswerText = answerDto.AnswerText;
                                            existingAnswer.IsCorrect = answerDto.IsCorrect;
                                            _unitOfWork.AnswerRepository.UpdateAsync(existingAnswer);
                                        }
                                    }
                                    else
                                    {
                                        // Add new answer
                                        var newAnswer = new Answer
                                        {
                                            QuestionId = existingQuestion.Id,
                                            AnswerText = answerDto.AnswerText,
                                            IsCorrect = answerDto.IsCorrect
                                        };
                                        await _unitOfWork.AnswerRepository.AddAsync(newAnswer);
                                    }
                                }
                            }

                            _unitOfWork.QuestionRepository.UpdateAsync(existingQuestion);
                        }
                    }
                    else
                    {
                        // Add new question
                        var newQuestion = new Question
                        {
                            QuizId = quiz.Id,
                            QuestionText = questionDto.QuestionText,
                            QuestionType = questionDto.QuestionType,
                            Points = questionDto.Points,
                            Answers = new List<Answer>()
                        };

                        if (questionDto.Answers != null)
                        {
                            foreach (var answerDto in questionDto.Answers)
                            {
                                newQuestion.Answers.Add(new Answer
                                {
                                    AnswerText = answerDto.AnswerText,
                                    IsCorrect = answerDto.IsCorrect
                                });
                            }
                        }

                        await _unitOfWork.QuestionRepository.AddAsync(newQuestion);
                    }
                }
            }

            _unitOfWork.QuizRepository.UpdateAsync(quiz);
            await _unitOfWork.CompleteAsync();

            // Refresh quiz with updated data
            quiz = await _unitOfWork.QuizRepository.GetQuizWithQuestionsAndAnswersAsync(quizId);

            return _mapper.Map<QuizDetailDto>(quiz);
        }
        public async Task DeleteQuizAsync(int courseId, int moduleId, int quizId, string instructorId)
        {
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(courseId);
            if (quiz == null || quiz.ModuleId != moduleId)
                throw new KeyNotFoundException($"Quiz with id {quizId} not found in module {moduleId}");

            await _unitOfWork.QuizRepository.DeleteAsync(quiz);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<QuizResultDto> SubmitQuizAsync(int courseId, int moduleId, int quizId, List<QuizSubmissionDto> submissions, string studentId)
        {
            var quiz = await _unitOfWork.QuizRepository.GetQuizWithQuestionsAndAnswersAsync(quizId);

            int totalPoints = quiz.Questions.Sum(q => q.Points);
            int earnedPoints = 0;

            foreach (var submission in submissions)
            {
                var question = quiz.Questions.FirstOrDefault(q => q.Id == submission.QuestionId);
                if (question == null)
                    continue;

                // For multiple choice questions
                if (question.QuestionType == "MultipleChoice" && submission.AnswerId.HasValue)
                {
                    var answer = question.Answers.FirstOrDefault(a => a.Id == submission.AnswerId.Value);
                    if (answer != null && answer.IsCorrect)
                    {
                        earnedPoints += question.Points;
                    }
                }
                // For text-based questions, would need instructor grading
                // Here we're just storing the submission
            }
            double scorePercentage = totalPoints > 0 ? (double)earnedPoints / totalPoints * 100 : 0;
            bool passed = scorePercentage >= quiz.PassingScore;

            // Create result DTO
            var result = new QuizResultDto
            {
                QuizId = quizId,
                TotalPoints = totalPoints,
                EarnedPoints = earnedPoints,
                ScorePercentage = scorePercentage,
                Passed = passed,
                SubmittedAt = DateTime.UtcNow
            };

            return result;
        }

        public async Task<QuizResultDto> GetQuizResultsAsync(int courseId, int moduleId, int quizId, string studentId)
        {
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(quizId);

            if (quiz == null || quiz.ModuleId != moduleId)
                throw new KeyNotFoundException($"Quiz with id {quizId} not found in module {moduleId}");

            return new QuizResultDto
            {
                QuizId = quizId,
                TotalPoints = 0,
                EarnedPoints = 0,
                ScorePercentage = 0,
                Passed = false,
                SubmittedAt = DateTime.UtcNow
            };
        }   
    }
}
