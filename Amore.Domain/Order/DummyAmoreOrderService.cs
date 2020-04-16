using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amore.Domain.Context;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using Microsoft.Extensions.Logging;

namespace Amore.Domain.Order
{
    public class DummyAmoreOrderService : IAmoreOrderService
    {
        private readonly ILogger<DummyAmoreOrderService> _logger;
        private readonly IAmoreCheckoutDataProvider _checkoutDataProvider;
        private readonly IOrderDao _orderDao;

        public DummyAmoreOrderService(ILogger<DummyAmoreOrderService> logger, IAmoreCheckoutDataProvider checkoutDataProvider, IOrderDao orderDao)
        {
            _logger = logger;
            _checkoutDataProvider = checkoutDataProvider;
            _orderDao = orderDao;
            _checkoutDataProvider.AmoreSessionId = Guid.NewGuid().ToString();
        }

        public void Order(Pizza pizza, List<Goodie> goodies)
        {
            _orderDao.AddPizzaOrder(new PizzaOrder(pizza, goodies, _checkoutDataProvider.AmoreSessionId));
            _logger.LogInformation($"Put order: {pizza.Name} with {goodies.Count} goodies");
        }

        public Task<CompleteOrderInfo> GetOrderInfo()
        {
            return _orderDao.GetOrderByOrderId(_checkoutDataProvider.AmoreSessionId);
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