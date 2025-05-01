namespace LMS.DTOs
{
    public class AssignmentDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxScore { get; set; }
        public string AttachmentUrl { get; set; }
        public DateTime DueDate { get; set; }

        // For student view
        public bool HasSubmitted { get; set; }
        public int? SubmissionId { get; set; }
        public int? SubmissionScore { get; set; }
        public string Feedback { get; set; }
    }
}
