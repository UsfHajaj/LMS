namespace LMS.DTOs
{
    public class UpdateQuizDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int PassingScore { get; set; }
        public bool IsActive { get; set; }
        public List<UpdateQuestionDto> Questions { get; set; }
    }
}
