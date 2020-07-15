using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amore.Domain.Data.Provider
{
    /// <summary>
    /// Provides access to www.thatsamore.at
    /// </summary>
    public interface IThatsAmoreWebSiteAccessProvider
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
    }
}