using System.Collections.Generic;
using System.Threading.Tasks;
using Amore.Data.Model;
using Amore.Data.Settings;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using MongoDB.Driver;

namespace Amore.Data.Dao
{
    public class MongoPizzaDao : IPizzaDao
    {
        private readonly IMongoCollection<MongoPizza> _collection;
        
        public MongoPizzaDao(IMongoPizzaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<MongoPizza>(settings.PizzasCollectionName);
        }

        public async Task<List<Pizza>> GetAll()
        {
            var pizzas = await _collection.FindAsync(pizza => true).Result.ToListAsync();
            return pizzas.Map();
        }

        public async Task<Pizza> GetById(string id)
        {
            var pizza = await _collection.FindAsync(p => p.Id == id).Result.FirstOrDefaultAsync();
            return pizza.Map();
        }
            
        
        public async Task<Pizza> GetByName(string name)
        {
            var pizza = await _collection.FindAsync(p => p.Name == name).Result.FirstOrDefaultAsync();
            return pizza.Map();
        }
    }
}