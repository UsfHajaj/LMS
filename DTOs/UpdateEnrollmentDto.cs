namespace LMS.DTOs
{
    public class UpdateEnrollmentDto
    {
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public bool IsCompleted { get; set; }
        public double ProgressPercentage { get; set; }
    }
}
