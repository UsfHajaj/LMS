using LMS.Models.Auth;

namespace LMS.Models.Social
{
    public class Comment
    {
        public int Id { get; set; }
        public int DiscussionId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }

        public virtual Discussion Discussion { get; set; }
        public virtual AppUser User { get; set; }
    }
}
