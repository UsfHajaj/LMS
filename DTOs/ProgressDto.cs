namespace LMS.DTOs
{
    public class ProgressDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int EnrollmentId { get; set; }
        public int LessonId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
