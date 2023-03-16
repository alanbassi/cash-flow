using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Infra.Data.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CashFlow.Infra.Data.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(MongoDbSettings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Transaction>> GetAllToday()
        {
            var filter = Builders<Transaction>.Filter.Gte(doc => doc.CreatedAt, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) &
                         Builders<Transaction>.Filter.Lt(doc => doc.CreatedAt, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));

            return await base.FilterBy(filter);
        }
    }
}