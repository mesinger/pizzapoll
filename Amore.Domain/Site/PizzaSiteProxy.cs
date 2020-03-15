using System.Collections.Generic;
using System.Threading.Tasks;

namespace amore.domain.Site
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

        public void PutOrder(string sessionId, IEnumerable<KeyValuePair<string, string>> orderData)
        {
            subject.PutOrder(sessionId, orderData);
        }
    }
}