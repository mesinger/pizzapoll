using System.Linq;
using System.Threading.Tasks;
using Amore.Data.Model;
using Amore.Data.Settings;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using MongoDB.Driver;

namespace Amore.Data.Dao
{
    public class MongoOrderDao : IOrderDao
    {
        private readonly IMongoCollection<MongoPizzaOrder> _collection;
        
        public MongoOrderDao(IMongoPizzaOrderDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<MongoPizzaOrder>(settings.PizzaOrdersCollectionName);
        }

        public void AddPizzaOrder(PizzaOrder order)
        {
            _collection.InsertOneAsync(order.Map());
        }

        public async Task<CompleteOrderInfo> GetOrderByOrderId(string orderId)
        {
            var orders = await _collection.FindAsync(o => o.OrderId == orderId).Result.ToListAsync();
            var subTotal = orders.Aggregate(0.0, (sum, order) => sum += order.SubTotal);
            var infos = orders.Select(o => (o.ProductName, o.ProductExtras, o.SubTotal));
            return new CompleteOrderInfo(subTotal, infos);
        }
    }
}