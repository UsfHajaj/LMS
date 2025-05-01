using LMS.Models.Interaction;

namespace LMS.Repositories.Interfaces
{
    public interface IPaymentRepository:IGenericRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetPaymentsByUserId(string userId);
        Task<IEnumerable<Payment>> GetPaymentsByCourseId(int courseId);

    }
}
