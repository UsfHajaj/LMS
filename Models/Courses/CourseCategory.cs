namespace LMS.Models.Courses
{
    public class CourseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }

        // العلاقات
        public virtual ICollection<Course> Courses { get; set; }
    }
}
