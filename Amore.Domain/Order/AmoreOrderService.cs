using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using Amore.Domain.Data.Provider;
using Microsoft.Extensions.Logging;

namespace Amore.Domain.Order
{
    public class AmoreOrderService : IAmoreOrderService
    {
        private readonly ISessionProvider _sessionProvider;
        private readonly ILogger<AmoreOrderService> _logger;
        private readonly IOrderDao _orderDao;
        private readonly IThatsAmoreWebSiteAccessProvider _webSiteAccessProvider;

        public AmoreOrderService(ISessionProvider sessionProvider, ILogger<AmoreOrderService> logger, IOrderDao orderDao, IThatsAmoreWebSiteAccessProvider webSiteAccessProvider)
        {
            _sessionProvider = sessionProvider;
            _logger = logger;
            _orderDao = orderDao;
            _webSiteAccessProvider = webSiteAccessProvider;
        }

        public void PutOrder(Pizza pizza, IEnumerable<Goodie> goodies)
        {
            if (_sessionProvider.HasCurrentSession())
            {
                var orderData = new List<KeyValuePair<string, string>>
                {
                    KeyValuePair.Create($"variants[{pizza.ProductOrderId}]", "1")
                };

                goodies.ToList().ForEach(goodie => orderData.Add(KeyValuePair.Create($"product_customizations[{pizza.ProductCustomizeId}][]", goodie.OrderId.ToString())));

                _webSiteAccessProvider.PutOrder(orderData);
            }
        }

        public void Checkout()
        {
            if (_sessionProvider.HasCurrentSession())
            {
                
            }
        }

        public Task<CompleteOrderInfo> GetOrderInfo()
        {
            return _orderDao.GetOrderByOrderId(_sessionProvider.GetCurrentSession());
        }

        public async Task<bool> OpenSession()
        {
            var sessionId = await _webSiteAccessProvider.GetSessionId();

            if (string.IsNullOrWhiteSpace(sessionId))
            {
                _logger.LogWarning("Cannot retrieve session id from amore");
                return false;
            }

            _sessionProvider.UpdateCurrentSession(sessionId);
            return true;
        }

        public void CloseSession()
        {
            _sessionProvider.UpdateCurrentSession(string.Empty);
        }
    }
} 