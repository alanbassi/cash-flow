using CashFlow.Domain.Enums;
using System;
using System.Text.Json.Serialization;

namespace CashFlow.Application.ViewModels
{
    public class TransactionViewModel
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public decimal Amount { get; set; }

        public TypeEnum Type { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}