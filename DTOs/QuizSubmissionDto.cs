namespace LMS.DTOs
{
    public class QuizSubmissionDto
    {
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public string TextAnswer { get; set; }
    }
}
