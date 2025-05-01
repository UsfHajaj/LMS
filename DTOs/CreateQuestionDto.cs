namespace LMS.DTOs
{
    public class CreateQuestionDto
    {
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public int Points { get; set; }
        public List<CreateAnswerDto> Answers { get; set; }
    }
}
