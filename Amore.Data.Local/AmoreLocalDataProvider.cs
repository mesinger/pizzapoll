using System.Collections.Generic;
using System.IO;
using System.Linq;
using Amore.Data.Local.Entity;
using Newtonsoft.Json;
using DomainPizza = Amore.Domain.Data.Model.Pizza;
using DomainGoodie = Amore.Domain.Data.Model.Goodie;

namespace Amore.Data.Local
{
    public class AmoreLocalDataProvider : IAmoreLocalDataProvider, IAmoreConfigurationLoader
    {
        private IEnumerable<Pizza> LoadedPizzas { get; set; } = Enumerable.Empty<Pizza>();
        private IEnumerable<DomainPizza> LoadedPizzasDomain { get; set; } = Enumerable.Empty<DomainPizza>();
        private Dictionary<string, DomainPizza> LoadedPizzasDomainById { get; set; } = new Dictionary<string, DomainPizza>();
        private IEnumerable<Goodie> LoadedGoodies { get; set; } = Enumerable.Empty<Goodie>();
        private Dictionary<string, DomainGoodie> LoadedGoodiesDomain { get; set; } = new Dictionary<string, DomainGoodie>();

        public async void Reload()
        {
            var pizzaConfiguration = File.ReadAllTextAsync("data/pizze.json");
            var goodieConfiguration = File.ReadAllTextAsync("data/goodie.json");
            
            LoadedPizzas = JsonConvert.DeserializeObject<IEnumerable<Pizza>>(await pizzaConfiguration);
            LoadedPizzasDomain = LoadedPizzas.Select(pizza => pizza.Map());
            LoadedPizzasDomainById = LoadedPizzasDomain.ToDictionary(pizza => pizza.Id, pizza => pizza);
            
            LoadedGoodies = JsonConvert.DeserializeObject<IEnumerable<Goodie>>(await goodieConfiguration);
            LoadedGoodiesDomain = LoadedGoodies.ToDictionary(goodie => goodie.Id, goodie => goodie.Map());
        }

        public IEnumerable<DomainPizza> GetAllPizzas()
        {
            return LoadedPizzasDomain;
        }

        public IEnumerable<DomainGoodie> GetAllGoodies()
        {
            return LoadedGoodiesDomain.Values;
        }

        public DomainPizza? GetPizzaById(string id)
        {
            return LoadedPizzasDomainById[id];
        }

        public DomainGoodie? GetGoodieById(string id)
        {
            return LoadedGoodiesDomain[id];
        }
    }
}