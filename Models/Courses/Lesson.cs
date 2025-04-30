using LMS.Models.Interaction;
using System.Net.Mail;
using System.Reflection;

namespace LMS.Models.Courses
{
    public class Lesson
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public int Order { get; set; }
        public TimeSpan Duration { get; set; }

        public virtual Modules Module { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Progress> ProgressRecords { get; set; }

    }
}
