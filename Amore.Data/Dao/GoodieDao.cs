using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Data.Models;
using MongoDB.Driver;

namespace Amore.Data.Dao
{
    public class GoodieDao : IGoodieDao
    {
        private readonly IMongoCollection<Goodie> _collection;
        
        public GoodieDao(IGoodiesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Goodie>(settings.GoodiesCollectionName);
        }

        public Task<List<Goodie>> GetAll() => _collection.FindAsync(_ => true).Result.ToListAsync();

        public Task<Goodie> GetById(string id) => _collection.FindAsync(goodie => goodie.Id == id).Result.FirstOrDefaultAsync();
        
        public Task<Goodie> GetByName(string name) =>
            _collection.FindAsync(goodie => goodie.Name == name).Result.FirstOrDefaultAsync();

        public Task<List<Goodie>> GetAllWithId(params string[] ids) =>
            _collection.FindAsync(goodie => ids.Contains(goodie.Id)).Result.ToListAsync();
    }
}