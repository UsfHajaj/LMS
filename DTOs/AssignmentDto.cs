namespace LMS.DTOs
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxScore { get; set; }
        public bool HasAttachment { get; set; }
        public DateTime DueDate { get; set; }
    }
}
