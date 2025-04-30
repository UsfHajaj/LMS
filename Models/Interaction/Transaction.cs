using LMS.Models.Auth;
using LMS.Models.Courses;

namespace LMS.Models.Interaction
{
    public class Transaction
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string TransactionType { get; set; }  
        public string PaymentMethod { get; set; }
        public string TransactionStatus { get; set; }  
        public string TransactionReference { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
