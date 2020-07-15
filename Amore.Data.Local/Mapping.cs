using System.Collections.Generic;
using System.Linq;
using Amore.Domain.Data.Model;

namespace Amore.Data.Local
{
    internal static class Mapping
    {
        public static Pizza Map(this Entity.Pizza pizza) => new Pizza(pizza.Id, pizza.Name, pizza.Description,
            pizza.Price, pizza.ProductOrderId, pizza.ProductCustomizeId, pizza.ProductImagePath,
            pizza.DefaultGoodiesIds, pizza.AdditionalGoodiesIds);

        public static List<Pizza> Map(this IEnumerable<Entity.Pizza> pizzas) =>
            pizzas.Select(pizza => pizza.Map()).ToList();

        public static Goodie Map(this Entity.Goodie goodie) =>
            new Goodie(goodie.Id, goodie.Name, goodie.OrderId, goodie.Price);
        public static List<Goodie> Map(this IEnumerable<Entity.Goodie> goodies) =>
            goodies.Select(goodie => goodie.Map()).ToList();
    }
}