using CashFlow.Domain.Enums;
using System;
using System.Xml.Linq;

namespace CashFlow.Domain.Commands
{
    public class RegisterNewTransactionCommand : TransactionCommand
    {
        public RegisterNewTransactionCommand(string title, TypeEnum type, string category, decimal amount)
        {
            Title = title;
            Type = type;
            Category = category;
            Amount = amount;
        }
    }
}
