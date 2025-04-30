using LMS.Models.Auth;

namespace LMS.Models.Social
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string NotificationType { get; set; }
        public string ReferenceId { get; set; }  

        public virtual AppUser User { get; set; }
    }
}
