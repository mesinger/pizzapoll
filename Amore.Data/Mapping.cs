using System.Collections.Generic;
using System.Linq;
using Amore.Data.Model;
using Amore.Domain.Data.Model;

namespace Amore.Data
{
    internal static class Mapping
    {
        public static Pizza Map(this MongoPizza pizza) => new Pizza(pizza.Id, pizza.Name, pizza.Description,
            pizza.Price, pizza.ProductOrderId, pizza.ProductCustomizeId, pizza.ProductImagePath,
            pizza.DefaultGoodiesIds, pizza.AdditionalGoodiesIds);

        public static List<Pizza> Map(this IEnumerable<MongoPizza> pizzas) =>
            pizzas.Select(pizza => pizza.Map()).ToList();

        public static Goodie Map(this MongoGoodie goodie) =>
            new Goodie(goodie.Id, goodie.Name, goodie.OrderId, goodie.Price);
        public static List<Goodie> Map(this IEnumerable<MongoGoodie> goodies) =>
            goodies.Select(goodie => goodie.Map()).ToList();
        
        public static MongoPizzaOrder Map(this PizzaOrder order) => new MongoPizzaOrder
        {
            OrderId = order.OrderId, ProductName = order.Pizza.Name,
            ProductExtras = string.Join(", ", order.Goodies.Select(g => g.Name))
        };
    }
}