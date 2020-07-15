using Newtonsoft.Json;

namespace Amore.Data.Local.Entity
{
    internal class Goodie
    {
        [JsonProperty("id")] public string Id { get; set; } = null!;
        [JsonProperty("name")] public string Name { get; set; } = null!;
        [JsonProperty("price")] public decimal Price { get; set; }
        [JsonProperty("orderId")] public int OrderId { get; set; }
    }
}