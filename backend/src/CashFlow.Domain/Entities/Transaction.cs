using CashFlow.Domain.Attributes;
using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    [BsonCollection("transaction")]
    public class Transaction : Entity
    {
        public string Title { get; set; }

        public TypeEnum Type { get; set; }

        public string Category { get; set; }

        public decimal Amount { get; set; }
    }
}
