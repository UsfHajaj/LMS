namespace LMS.DTOs
{
    public class CreateQuizDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int PassingScore { get; set; }
        public bool IsActive { get; set; }
        public List<CreateQuestionDto> Questions { get; set; }
    }
}
