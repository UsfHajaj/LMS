namespace LMS.DTOs
{
    public class CreateTransactionDto
    {
        public string StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string TransactionType { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionReference { get; set; }
    }
}
