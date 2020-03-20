using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Amore.Data.Models
{
    public class Pizza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("product_order_id")]
        public string ProductOrderId { get; set; }

        [BsonElement("product_customize_id")]
        public string ProductCustomizeId { get; set; }
        
        [BsonElement("product_image_path")] 
        public string ProductImagePath { get; set; }

        [BsonElement("default_goodies")]
        public List<string> DefaultGoodiesIds { get; set; }

        [BsonElement("additional_goodies")]
        public List<string> AdditionalGoodiesIds { get; set; }
    }
}