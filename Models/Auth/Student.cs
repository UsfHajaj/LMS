using LMS.Models.Interaction;

namespace LMS.Models.Auth
{
    public class Student:AppUser
    {
        public string? EducationLevel { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
