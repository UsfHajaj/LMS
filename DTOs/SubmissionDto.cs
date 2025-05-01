namespace LMS.DTOs
{
    public class SubmissionDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string SubmissionText { get; set; }
        public string AttachmentUrl { get; set; }
        public int? Score { get; set; }
        public string Feedback { get; set; }
    }
}
