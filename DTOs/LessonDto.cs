namespace LMS.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public int Order { get; set; }
        public TimeSpan Duration { get; set; }
        public string ModuleTitle { get; set; } 
    }
}
