using System.Collections.Generic;
using Newtonsoft.Json;

namespace Amore.Data.Local.Entity
{
    internal class Pizza
    {
        [JsonProperty("id")] public string Id { get; set; } = null!;
        [JsonProperty("name")] public string Name { get; set; } = null!;
        [JsonProperty("description")] public string Description { get; set; } = null!;
        [JsonProperty("price")] public decimal Price { get; set; }
        [JsonProperty("defaultGoodies")] public IEnumerable<string> DefaultGoodiesIds { get; set; } = null!;
        [JsonProperty("additionalGoodies")] public IEnumerable<string> AdditionalGoodiesIds { get; set; } = null!;
        [JsonProperty("productOrderId")] public string ProductOrderId { get; set; } = null!;
        [JsonProperty("productCustomizeId")] public string ProductCustomizeId { get; set; } = null!;
        [JsonProperty("productImagePath")] public string ProductImagePath { get; set; } = null!;
    }
}