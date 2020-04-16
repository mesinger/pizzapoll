
using System.Collections.Generic;
using System.Threading.Tasks;
using Amore.Domain.Context;
using Amore.Domain.Data.Model;
using Amore.Domain.Site;
using Microsoft.Extensions.Logging;

namespace Amore.Domain.Order
{
    public class AmoreOrderService : IAmoreOrderService
    {
        private readonly IAmoreCheckoutDataProvider _checkoutDataProvider;
        private readonly ILogger<AmoreOrderService> _logger;
        private readonly IPizzaSiteProxy _pizzaSiteProxy;

        public AmoreOrderService(IAmoreCheckoutDataProvider checkoutDataProvider, ILogger<AmoreOrderService> logger, IPizzaSiteProxy pizzaSiteProxy)
        {
            _checkoutDataProvider = checkoutDataProvider;
            _logger = logger;
            _pizzaSiteProxy = pizzaSiteProxy;
        }

        public void Order(Pizza pizza, List<Goodie> goodies)
        {
            if (_checkoutDataProvider.HasCurrentSession())
            {
                var orderData = new List<KeyValuePair<string, string>>
                {
                    KeyValuePair.Create($"variants[{pizza.ProductOrderId}]", "1")
                };

                goodies.ForEach(goodie => orderData.Add(KeyValuePair.Create($"product_customizations[{pizza.ProductCustomizeId}][]", goodie.OrderId.ToString())));

                _pizzaSiteProxy.PutOrder(orderData);
            }
        }

        public Task<CompleteOrderInfo> GetOrderInfo()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> OpenSession()
        {
            var sessionId = await _pizzaSiteProxy.GetSessionId();

            if (string.IsNullOrWhiteSpace(sessionId))
            {
                _logger.LogWarning("Cannot retrieve session id from amore");
                return false;
            }

            _checkoutDataProvider.AmoreSessionId = sessionId;
            return true;
        }

        public void CloseSession()
        {
            _checkoutDataProvider.AmoreSessionId = string.Empty;
        }
    }
} 