namespace LMS.DTOs
{
    public class EditLessonDto
    {
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public int Order { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
