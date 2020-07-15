using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;

namespace Amore.Data.Local.Dao
{
    public class LocalPizzaDao : IPizzaDao
    {
        private readonly IAmoreLocalDataProvider _dataProvider;

        public LocalPizzaDao(IAmoreLocalDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Task<IEnumerable<Pizza>> GetAll()
        {
            return Task.FromResult(_dataProvider.GetAllPizzas());
        }

        public Task<Pizza?> GetById(string id)
        {
            return Task.FromResult(_dataProvider.GetPizzaById(id));
        }

        public async Task<Pizza?> GetByName(string name)
        {
            var pizzas = await GetAll();
            return pizzas.FirstOrDefault(p => p.Name == name);
        }
    }
}