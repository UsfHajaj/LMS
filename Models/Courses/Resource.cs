namespace LMS.Models.Courses
{
    public class Resource
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceType { get; set; } 
        public string ResourceUrl { get; set; }

        public virtual Course Course { get; set; }
    }
}
