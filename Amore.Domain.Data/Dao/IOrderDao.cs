using System.Collections.Generic;
using System.Threading.Tasks;
using Amore.Domain.Data.Model;

namespace Amore.Domain.Data.Dao
{
    /// <summary>
    /// Access to orders
    /// </summary>
    public interface IOrderDao
    {
        /// <summary>
        /// Saves a given pizza order
        /// </summary>
        /// <param name="order"></param>
        void AddPizzaOrder(PizzaOrder order);

        /// <summary>
        /// Retrieve a order by a given order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<CompleteOrderInfo> GetOrderByOrderId(string orderId);
    }
}