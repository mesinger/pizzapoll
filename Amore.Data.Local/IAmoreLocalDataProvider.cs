using System.Collections.Generic;
using Amore.Domain.Data.Model;

namespace Amore.Data.Local
{
    /// <summary>
    /// Provides raw data for pizza and goodies
    /// </summary>
    public interface IAmoreLocalDataProvider
    {
        /// <summary>
        /// Returns all locally stored pizzas
        /// </summary>
        /// <returns></returns>
        IEnumerable<Pizza> GetAllPizzas();
        
        /// <summary>
        /// Returns all locally stored goodies
        /// </summary>
        /// <returns></returns>
        IEnumerable<Goodie> GetAllGoodies();

        /// <summary>
        /// Retrieves a pizza by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pizza? GetPizzaById(string id);
        
        /// <summary>
        /// Retrieves a goodie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Goodie? GetGoodieById(string id);
    }
}