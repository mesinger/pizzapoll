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
    }
}