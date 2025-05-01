namespace LMS.DTOs
{
    public class QuizDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int PassingScore { get; set; }
        public bool IsActive { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
