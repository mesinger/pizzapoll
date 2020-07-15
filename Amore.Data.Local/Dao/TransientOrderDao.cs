using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using Microsoft.Extensions.Logging;

namespace Amore.Data.Local.Dao
{
    public class TransientOrderDao : IOrderDao
    {
        private readonly ILogger<TransientOrderDao> _logger;

        public TransientOrderDao(ILogger<TransientOrderDao> logger)
        {
            _logger = logger;
        }

        public Dictionary<string, List<PizzaOrder>> TransientOrderHistory { get; } = new Dictionary<string, List<PizzaOrder>>();

        public void AddPizzaOrder(PizzaOrder order)
        {
            _logger.LogInformation("Added pizza order: {}", order.Pizza.Name);

            if (!TransientOrderHistory.ContainsKey(order.OrderId))
            {
                TransientOrderHistory[order.OrderId] = new List<PizzaOrder>();
            }
            
            TransientOrderHistory[order.OrderId].Add(order);
        }

        public Task<CompleteOrderInfo> GetOrderByOrderId(string orderId)
        {
            if (!TransientOrderHistory.ContainsKey(orderId))
            {
                return Task.FromResult(new CompleteOrderInfo(0.0, Enumerable.Empty<(string, string, double)>()));
            }
            
            var orders = TransientOrderHistory[orderId];
            
            var subTotal = (double) orders.Select(order =>
                (order.Pizza.Price + order.Goodies.Where(g => !order.Pizza.DefaultGoodiesIds.Contains(g.Id))
                    .Select(g => g.Price).Sum())).Sum();
            
            var infos = orders.Select(o => (o.Pizza.Name, string.Join(", ", o.Goodies.Select(g => g.Name)), (double) (o.Pizza.Price + o.Goodies.Where(g => !o.Pizza.DefaultGoodiesIds.Contains(g.Id))
                .Select(g => g.Price).Sum())));
            
            return Task.FromResult(new CompleteOrderInfo(subTotal, infos));
        }
    }
}