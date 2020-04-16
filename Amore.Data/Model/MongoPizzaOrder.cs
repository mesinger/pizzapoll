using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Amore.Data.Model
{
    public class MongoPizzaOrder
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("order-id")] 
        public string OrderId { get; set; }
        
        [BsonElement("product-name")]
        public string ProductName { get; set; }
        
        [BsonElement("product-extras")]
        public string ProductExtras { get; set; }
    }
}