namespace LMS.DTOs
{
    public class UpdateProgressDto
    {
        public int EnrollmentId { get; set; }
        public int LessonId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
