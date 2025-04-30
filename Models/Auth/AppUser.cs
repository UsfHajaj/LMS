using LMS.Models.Social;
using Microsoft.AspNetCore.Identity;

namespace LMS.Models.Auth
{
    public class AppUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
    }
}
