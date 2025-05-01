namespace LMS.DTOs
{
    public class QuizResultDto
    {
        public int QuizId { get; set; }
        public int TotalPoints { get; set; }
        public int EarnedPoints { get; set; }
        public double ScorePercentage { get; set; }
        public bool Passed { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
