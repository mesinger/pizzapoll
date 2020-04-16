using System.Collections.Generic;

namespace Amore.Domain.Data.Model
{
    public class PizzaOrder
    {
        public PizzaOrder(Pizza pizza, List<Goodie> goodies, string orderId)
        {
            Pizza = pizza;
            Goodies = goodies;
            OrderId = orderId;
        }

        public string OrderId { get; }
        public Pizza Pizza { get; }
        public List<Goodie> Goodies { get; }
    }
}