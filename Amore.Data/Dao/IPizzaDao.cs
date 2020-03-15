using System.Collections.Generic;
using System.Threading.Tasks;
using Amore.Data.Models;

namespace Amore.Data.Dao
{
    /// <summary>
    /// Provides access to pizza items
    /// </summary>
    public interface IPizzaDao
    {
        /// <summary>
        /// Returns all pizza items
        /// </summary>
        /// <returns></returns>
        Task<List<Pizza>> GetAll();

        /// <summary>
        /// Returns a pizza item with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Pizza> GetById(string id);
        
        /// <summary>
        /// Returns a pizza with a given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Pizza> GetByName(string name);
    }
}