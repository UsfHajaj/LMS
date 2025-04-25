using LMS.Models.Courses;

namespace LMS.Models.Auth
{
    public class Instructor:AppUser
    {
        public string? Specialization { get; set; }
        public string? Skills { get; set; }
        public string? Experience { get; set; }
        public double? Rating { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
