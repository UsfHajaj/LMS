using LMS.DTOs;

namespace LMS.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
        Task<IEnumerable<PaymentDto>> GetAllPaymentsByUserIdAsync(string userId);
        Task<IEnumerable<PaymentDto>> GetAllPaymentsBycourseIdAsync(int courseId);
        Task<PaymentDto> GetPaymentById(int id);
        Task<PaymentDto> CreatePayment(CreatePaymentDto paymentDto);
        Task DeletePayment(int id);

    }
}
