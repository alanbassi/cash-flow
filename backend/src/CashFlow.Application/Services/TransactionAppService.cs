using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Commands;
using CashFlow.Domain.Interfaces;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace CashFlow.Application.Services
{
    public class TransactionAppService : ITransactionAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionAppService(IMapper mapper, IMediatorHandler mediator, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionViewModel>> GetAllToday()
        {
            return _mapper.Map<IEnumerable<TransactionViewModel>>(await _transactionRepository.GetAllToday());
        }

        public async Task<ValidationResult> Add(TransactionViewModel transactionViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewTransactionCommand>(transactionViewModel);
            return await _mediator.SendCommand(registerCommand);
        }
    }
}
