using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;

namespace Amore.Data.Local.Dao
{
    public class LocalGoodieDao : IGoodieDao
    {
        private readonly IAmoreLocalDataProvider _dataProvider;

        public LocalGoodieDao(IAmoreLocalDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Task<IEnumerable<Goodie>> GetAll()
        {
            return Task.FromResult(_dataProvider.GetAllGoodies());
        }

        public Task<Goodie?> GetById(string id)
        {
            return Task.FromResult(_dataProvider.GetGoodieById(id));
        }

        public async Task<Goodie> GetByName(string name)
        {
            var goodies = await GetAll();
            var goodie = goodies.FirstOrDefault(g => g.Name == name);
            return await Task.FromResult(goodie);
        }

        public async Task<IEnumerable<Goodie>> GetAllWithId(params string[] ids)
        {
            var goodies = await GetAll();
            return goodies.Where(g => ids.Contains(g.Id));
        }
    }
}