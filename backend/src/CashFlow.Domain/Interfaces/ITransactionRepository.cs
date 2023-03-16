using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAllToday();
    }
}
