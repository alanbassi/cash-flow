using AutoMapper;
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Transaction, TransactionViewModel>();
        }
    }
}
