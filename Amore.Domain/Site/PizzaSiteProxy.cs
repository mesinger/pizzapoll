using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amore.Domain.Site
{
    public class PizzaSiteProxy : IPizzaSiteProxy
    {
        public PizzaSiteProxy(IPizzaSiteProxyFactory pizzaSiteProxyFactory)
        {
            subject = pizzaSiteProxyFactory.Create(PizzaPlace.AMORE);
        }

        private readonly IPizzaSiteProxy subject;
        
        public async Task<string> GetSessionId()
        {
            return await subject.GetSessionId();
        }

        public void PutOrder(IEnumerable<KeyValuePair<string, string>> orderData)
        {
            subject.PutOrder(orderData);
        }

        public void PrepareCheckout()
        {
            subject.PrepareCheckout();
        }

        public void Checkout()
        {
            subject.Checkout();
        }
    }
}