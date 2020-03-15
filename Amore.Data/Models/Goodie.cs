using MongoDB.Bson.Serialization.Attributes;

namespace Amore.Data.Models
{
    public class Goodie
    {
        [BsonId]
        public string Id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("order_id")]
        public int OrderId { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}