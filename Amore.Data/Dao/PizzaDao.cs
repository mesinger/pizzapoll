using System.Collections.Generic;
using System.Threading.Tasks;
using Amore.Data.Models;
using MongoDB.Driver;

namespace Amore.Data.Dao
{
    public class PizzaDao : IPizzaDao
    {
        private readonly IMongoCollection<Pizza> _collection;
        
        public PizzaDao(IPizzasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Pizza>(settings.PizzasCollectionName);
        }

        public Task<List<Pizza>> GetAll() => _collection.FindAsync(pizza => true).Result.ToListAsync();

        public Task<Pizza> GetById(string id) => _collection.FindAsync(pizza => pizza.Id == id).Result.FirstOrDefaultAsync();
        
        public Task<Pizza> GetByName(string name) =>
            _collection.FindAsync(pizza => pizza.Name == name).Result.FirstOrDefaultAsync();
    }
}