using System.Collections.Generic;
using System.Threading.Tasks;
using Amore.Domain.Data.Model;

namespace Amore.Domain.Data.Dao
{
    /// <summary>
    /// Returns pizza goodies
    /// </summary>
    public interface IGoodieDao
    {
        /// <summary>
        /// Returns all available pizza goodies
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Goodie>> GetAll();

        /// <summary>
        /// Returns a goodie by given id
        /// </summary>
        /// <returns></returns>
        Task<Goodie?> GetById(string id);

        /// <summary>
        /// Returns a goodie with a given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Goodie> GetByName(string name);

        /// <summary>
        /// Returns all goodies with given ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IEnumerable<Goodie>> GetAllWithId(params string[] ids);
    }
}