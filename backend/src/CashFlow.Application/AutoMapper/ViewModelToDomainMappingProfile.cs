using AutoMapper;
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Commands;

namespace CashFlow.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TransactionViewModel, RegisterNewTransactionCommand>()
                .ConstructUsing(c => new RegisterNewTransactionCommand(c.Title, c.Type, c.Category, c.Amount));
        }
    }
}
