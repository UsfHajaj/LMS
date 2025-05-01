using LMS.Models.Context;
using LMS.Models.Interaction;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCourseId(int courseId)
        {
            return await _dbSet
                .Where(m => courseId == courseId)
                .ToListAsync();

        }

        public async Task<IEnumerable<Payment>> GetPaymentsByUserId(string userId)
        {
            return await _dbSet
                .Include(m=>m.Transaction)
                .Where(m=>m.Transaction.StudentId==userId)
                .ToListAsync();
        }
    }
}
