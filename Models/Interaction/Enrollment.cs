using LMS.Models.Auth;
using LMS.Models.Courses;

namespace LMS.Models.Interaction
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public bool IsCompleted { get; set; }
        public double ProgressPercentage { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}
