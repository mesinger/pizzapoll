using System.Collections.Generic;

namespace Amore.Domain.Data.Model
{
    public class Pizza
    {
        public Pizza(string id, string name, string description, decimal price, string productOrderId, string productCustomizeId, string productImagePath, List<string> defaultGoodiesIds, List<string> additionalGoodiesIds)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ProductOrderId = productOrderId;
            ProductCustomizeId = productCustomizeId;
            ProductImagePath = productImagePath;
            DefaultGoodiesIds = defaultGoodiesIds;
            AdditionalGoodiesIds = additionalGoodiesIds;
        }

        public string Id { get; }

        public string Name { get; }

        public string Description { get; }

        public decimal Price { get; }

        public string ProductOrderId { get; }

        public string ProductCustomizeId { get; }
        
        public string ProductImagePath { get; }

        public List<string> DefaultGoodiesIds { get; }

        public List<string> AdditionalGoodiesIds { get; }
    }
}