using CashFlow.Domain.Enums;
using MediatR;
using NetDevPack.Messaging;

namespace CashFlow.Domain.Commands
{
    public abstract class TransactionCommand : Command
    {
        public string Id { get; protected set; }

        public TypeEnum Type { get; set; }

        public string Title { get; protected set; }

        public string Category { get; protected set; }

        public decimal Amount { get; protected set; }

        public DateTime CreatedAt { get; protected set; }
}
}
