using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Data.Model;
using Amore.Data.Settings;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using MongoDB.Driver;

namespace Amore.Data.Dao
{
    public class MongoGoodieDao : IGoodieDao
    {
        private readonly IMongoCollection<MongoGoodie> _collection;
        
        public MongoGoodieDao(IMongoGoodieDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<MongoGoodie>(settings.GoodiesCollectionName);
        }

        public async Task<List<Goodie>> GetAll()
        {
            var goodie = await _collection.FindAsync(_ => true).Result.ToListAsync();
            return goodie.Map();
        }

        public async Task<Goodie> GetById(string id)
        {
            var goodie = await _collection.FindAsync(g => g.Id == id).Result.FirstOrDefaultAsync();
            return goodie.Map();
        } 
        
        public async Task<Goodie> GetByName(string name)
        {
            var goodie = await _collection.FindAsync(g => g.Name == name).Result.FirstOrDefaultAsync();
            return goodie.Map();
        }

        public async Task<List<Goodie>> GetAllWithId(params string[] ids)
        { 
            var goodies = await _collection.FindAsync(goodie => ids.Contains(goodie.Id)).Result.ToListAsync();
            return goodies.Map();
        }
    }
}