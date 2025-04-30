using LMS.Models.Auth;
using LMS.Models.Courses;

namespace LMS.Models.Interaction
{
    public class Progress
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int EnrollmentId { get; set; }
        public int LessonId { get; set; }
        public bool IsCompleted { get; set; }

        public virtual Student Student { get; set; }
        public virtual Enrollment Enrollment { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
