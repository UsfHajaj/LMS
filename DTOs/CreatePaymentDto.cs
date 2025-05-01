namespace LMS.DTOs
{
    public class CreatePaymentDto
    {
        // Transaction Info
        public string StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }

        // Payment Info
        public string PaymentGateway { get; set; }
        public string PaymentId { get; set; }
        public string PaymentStatus { get; set; }
    }
}
