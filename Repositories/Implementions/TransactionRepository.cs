using LMS.Models.Context;
using LMS.Repositories.Interfaces;
using LMS.Models.Interaction;

namespace LMS.Repositories.Implementions
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
