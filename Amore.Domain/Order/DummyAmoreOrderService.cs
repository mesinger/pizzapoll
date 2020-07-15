using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using Amore.Domain.Data.Provider;
using Microsoft.Extensions.Logging;

namespace Amore.Domain.Order
{
    public class DummyAmoreOrderService : IAmoreOrderService
    {
        private readonly ILogger<DummyAmoreOrderService> _logger;
        private readonly ISessionProvider _sessionProvider;
        private readonly IOrderDao _orderDao;

        public DummyAmoreOrderService(ILogger<DummyAmoreOrderService> logger, ISessionProvider sessionProvider, IOrderDao orderDao)
        {
            _logger = logger;
            _sessionProvider = sessionProvider;
            _orderDao = orderDao;
            _sessionProvider.UpdateCurrentSession(Guid.NewGuid().ToString());
        }

        public void PutOrder(Pizza pizza, IEnumerable<Goodie> goodies)
        {
            _orderDao.AddPizzaOrder(new PizzaOrder(pizza, goodies, _sessionProvider.GetCurrentSession()));
            _logger.LogInformation($"Put order: {pizza.Name} with {goodies.Count()} goodies");
        }

        public async void Checkout()
        {
            var currentOrder = await GetOrderInfo();
            _logger.LogInformation($"Checkout: Subtotal = {currentOrder.SubTotal}");
        }

        public Task<CompleteOrderInfo> GetOrderInfo()
        {
            return _orderDao.GetOrderByOrderId(_sessionProvider.GetCurrentSession());
        }

        public Task<bool> OpenSession()
        {
            _logger.LogInformation("Opening new amore order session");
            return null;
        }

        public void CloseSession()
        {
            _logger.LogInformation("Closing amore order session");
            _sessionProvider.UpdateCurrentSession(string.Empty);
        }
    }
}