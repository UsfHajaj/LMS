namespace LMS.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public int Points { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
