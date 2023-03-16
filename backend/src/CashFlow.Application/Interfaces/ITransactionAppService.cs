using CashFlow.Application.ViewModels;
using FluentValidation.Results;

namespace CashFlow.Application.Interfaces
{
    public interface ITransactionAppService
    {
        Task<ValidationResult> Add(TransactionViewModel entity);
        Task<IEnumerable<TransactionViewModel>> GetAllToday();
    }
}