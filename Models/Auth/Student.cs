using LMS.Models.Interaction;
using System;

namespace LMS.Models.Auth
{
    public class Student:AppUser
    {
        public string? EducationLevel { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Progress> ProgressRecords { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
