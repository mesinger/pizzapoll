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
    }
}