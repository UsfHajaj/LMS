using LMS.Models.Auth;
using LMS.Models.Enums;
using LMS.Models.Interaction;
using LMS.Models.Social;
using System.Reflection;

namespace LMS.Models.Courses
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string InstructorId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int EnrollmentCount { get; set; }
        public double Rating { get; set; }
        public CourseLevels Level { get; set; } = CourseLevels.junior;
        public string Language { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual CourseCategory Category { get; set; }
        public virtual ICollection<Modules> Modules { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
