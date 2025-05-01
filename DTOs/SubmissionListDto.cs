namespace LMS.DTOs
{
    public class SubmissionListDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool HasAttachment { get; set; }
        public int? Score { get; set; }
        public bool IsGraded { get; set; }
    }
}
