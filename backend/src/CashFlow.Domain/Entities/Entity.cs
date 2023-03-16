using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CashFlow.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
