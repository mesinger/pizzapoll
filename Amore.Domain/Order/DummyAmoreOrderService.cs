using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Data.Models;
using Microsoft.Extensions.Logging;

namespace Amore.Domain.Order
{
    public class DummyAmoreOrderService : IAmoreOrderService
    {
        private readonly ILogger<DummyAmoreOrderService> _logger;

        public DummyAmoreOrderService(ILogger<DummyAmoreOrderService> logger)
        {
            _logger = logger;
        }

        public void Order(Pizza pizza, List<Goodie> goodies)
        {
            _logger.LogDebug($"Put order: {pizza.Name} with goodies {goodies.Select(goodie => goodie.Name)}");
        }

        public Task<bool> OpenSession()
        {
            _logger.LogInformation("Opening new amore order session");
            return null;
        }

        public void CloseSession()
        {
            _logger.LogInformation("Closing amore order session");
        }
    }
}