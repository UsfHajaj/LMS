using LMS.Models.Auth;

namespace LMS.Models.Interaction
{
    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string StudentId { get; set; }
        public string SubmissionText { get; set; }
        public string AttachmentUrl { get; set; }
        public int? Score { get; set; }
        public string Feedback { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual Student Student { get; set; }
    }
}
