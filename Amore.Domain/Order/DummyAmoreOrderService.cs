using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Data.Models;
using Amore.Domain.Context;
using Microsoft.Extensions.Logging;

namespace Amore.Domain.Order
{
    public class DummyAmoreOrderService : IAmoreOrderService
    {
        private readonly ILogger<DummyAmoreOrderService> _logger;
        private readonly IAmoreCheckoutDataProvider _checkoutDataProvider;

        public DummyAmoreOrderService(ILogger<DummyAmoreOrderService> logger, IAmoreCheckoutDataProvider checkoutDataProvider)
        {
            _logger = logger;
            _checkoutDataProvider = checkoutDataProvider;
            _checkoutDataProvider.AmoreSessionId = "mockedsessionid";
        }

        public void Order(Pizza pizza, List<Goodie> goodies)
        {
            _logger.LogInformation($"Put order: {pizza.Name} with {goodies.Count} goodies");
        }

        public Task<bool> OpenSession()
        {
            _logger.LogInformation("Opening new amore order session");
            _checkoutDataProvider.AmoreSessionId = "mockedsessionid";
            return null;
        }

        public void CloseSession()
        {
            _logger.LogInformation("Closing amore order session");
            _checkoutDataProvider.AmoreSessionId = string.Empty;
        }
    }
}