namespace LMS.DTOs
{
    public class UpdateQuestionDto
    {
        public int? Id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public int Points { get; set; }
        public List<UpdateAnswerDto> Answers { get; set; }
    }
}
