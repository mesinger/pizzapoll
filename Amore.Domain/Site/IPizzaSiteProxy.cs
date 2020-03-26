using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amore.Domain.Site
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
        void PutOrder(IEnumerable<KeyValuePair<string, string>> orderData);

        /// <summary>
        /// Prepares an order for checkout
        /// </summary>
        void PrepareCheckout();

        /// <summary>
        /// Finishes an order and sends it to the pizza website
        /// </summary>
        void Checkout();
    }
}