namespace LMS.DTOs
{
    public class ModulesDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string CourseName { get; set; }
    }
}
