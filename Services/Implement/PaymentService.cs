using AutoMapper;
using LMS.DTOs;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;

namespace LMS.Services.Implement
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public PaymentService(IPaymentRepository repository,IMapper mapper,ITransactionRepository transactionRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }
        public async Task<PaymentDto> CreatePayment(CreatePaymentDto paymentDto)
        {
            // 1. إنشاء Transaction
            var transaction = new Transaction
            {
                StudentId = paymentDto.StudentId,
                CourseId = paymentDto.CourseId,
                SubscriptionId = paymentDto.SubscriptionId,
                Amount = paymentDto.Amount,
                Currency = paymentDto.Currency,
                PaymentMethod = paymentDto.PaymentMethod,
                TransactionType = "Payment",
                TransactionStatus = "Completed", 
                TransactionReference = Guid.NewGuid().ToString()
            };
            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveChangesAsync();

            var payment = new Payment
            {
                TransactionId = transaction.Id,
                PaymentGateway = paymentDto.PaymentGateway,
                PaymentId = paymentDto.PaymentId,
                Amount = paymentDto.Amount,
                Currency = paymentDto.Currency,
                PaymentStatus = paymentDto.PaymentStatus
            };
            await _repository.AddAsync(payment);
            await _repository.SaveChangesAsync();
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task DeletePayment(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(result);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            var result=await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(result);
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsBycourseIdAsync(int courseId)
        {
            var result = await _repository.GetPaymentsByCourseId(courseId);
            return _mapper.Map<IEnumerable<PaymentDto>>(result);
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsByUserIdAsync(string userId)
        {
            var result = await _repository.GetPaymentsByUserId(userId);
            return _mapper.Map<IEnumerable<PaymentDto>>(result);
        }

        public async Task<PaymentDto> GetPaymentById(int id)
        {
            var payment=await _repository.GetByIdAsync(id);
            return _mapper.Map<PaymentDto>(payment);
        }
    }
}
