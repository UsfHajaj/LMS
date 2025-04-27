namespace LMS.DTOs
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public bool IsCompleted { get; set; }
        public double ProgressPercentage { get; set; }
        public string StudentName { get; set; }
        public string CourseTitle { get; set; }
    }
}
