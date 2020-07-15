using System.Collections.Generic;

namespace Amore.Domain.Data.Model
{
    public class Pizza
    {
        public Pizza(string id, string name, string description, decimal price, string productOrderId, string productCustomizeId, string productImagePath, IEnumerable<string> defaultGoodiesIds, IEnumerable<string> additionalGoodiesIds)
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

        public IEnumerable<string> DefaultGoodiesIds { get; }

        public IEnumerable<string> AdditionalGoodiesIds { get; }
    }
}