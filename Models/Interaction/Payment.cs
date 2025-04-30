namespace LMS.Models.Interaction
{
    public class Payment
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string PaymentGateway { get; set; }
        public string PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentStatus { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
