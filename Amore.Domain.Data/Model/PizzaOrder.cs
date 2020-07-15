using System.Collections.Generic;

namespace Amore.Domain.Data.Model
{
    public class PizzaOrder
    {
        public PizzaOrder(Pizza pizza, IEnumerable<Goodie> goodies, string orderId)
        {
            Pizza = pizza;
            Goodies = goodies;
            OrderId = orderId;
        }

        public string OrderId { get; }
        public Pizza Pizza { get; }
        public IEnumerable<Goodie> Goodies { get; }
    }
}