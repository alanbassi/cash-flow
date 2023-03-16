using CashFlow.Domain.Commands;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Equinox.Domain.Commands
{
    public class TransactionCommandHandler : IRequestHandler<RegisterNewTransactionCommand, ValidationResult>
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewTransactionCommand message, CancellationToken cancellationToken)
        {
            var transaction = new Transaction()
            {
                Amount = message.Amount,
                Type= message.Type,
                Category = message.Category,
                Title = message.Title
            };

            await _transactionRepository.Add(transaction);

            return new ValidationResult();
        }
    }
}