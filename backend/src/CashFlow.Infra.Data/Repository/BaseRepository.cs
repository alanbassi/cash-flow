using CashFlow.Domain.Attributes;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Infra.Data.Settings;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace CashFlow.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public BaseRepository(MongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public async Task Add(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> FilterBy(FilterDefinition<TEntity> filterExpression)
        {
            return (await _collection.FindAsync(filterExpression)).ToEnumerable();
        }
    }
}
