namespace Amore.Domain.Data.Model
{
    public class Goodie
    {
        public Goodie(string id, string name, int orderId, decimal price)
        {
            Id = id;
            Name = name;
            OrderId = orderId;
            Price = price;
        }

        public string Id { get; }
        
        public string Name { get; }

        public int OrderId { get; }

        public decimal Price { get; }
    }
}