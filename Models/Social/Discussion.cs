using LMS.Models.Auth;
using LMS.Models.Courses;

namespace LMS.Models.Social
{
    public class Discussion
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual Course Course { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
