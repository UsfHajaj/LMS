using LMS.Models.Auth;

namespace LMS.Models.Interaction
{
    public class Subscription
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string SubscriptionPlan { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool AutoRenew { get; set; }
        public string PaymentMethod { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
