using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CashFlow.Domain.Enums
{
    [JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumMemberConverter))]
    public enum TypeEnum
    {
        [EnumMember(Value = "credit")]
        Credit,
        [EnumMember(Value = "debit")]
        Debit
    }
}
