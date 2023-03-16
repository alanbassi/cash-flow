using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task Add(TEntity entity);
    }
}
