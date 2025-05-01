namespace LMS.DTOs
{
    public class CreatePaymentWithTransactionDto
    {
        public CreatePaymentDto Payment { get; set; }
        public CreateTransactionDto Transaction { get; set; }
    }
}
