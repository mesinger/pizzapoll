using System.Collections.Generic;
using System.Threading.Tasks;

namespace amore.domain.Site
{
    /// <summary>
    /// Access to a real pizza website
    /// </summary>
    public interface IPizzaSiteProxy
    {
        /// <summary>
        /// Returns a session id from a pizza site
        /// </summary>
        /// <returns></returns>
        Task<string> GetSessionId();

        /// <summary>
        /// Puts an order into the cart on a pizza website
        /// </summary>
        void PutOrder(string sessionId, IEnumerable<KeyValuePair<string, string>> orderData);
    }
}