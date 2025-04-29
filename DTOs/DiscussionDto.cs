namespace LMS.DTOs
{
    public class DiscussionDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CourseName { get; set; }
        public string UserName { get; set; }

    }
}
