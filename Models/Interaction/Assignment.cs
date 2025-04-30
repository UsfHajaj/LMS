using LMS.Models.Courses;

namespace LMS.Models.Interaction
{
    public class Assignment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxScore { get; set; }
        public string AttachmentUrl { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
