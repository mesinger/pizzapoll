﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Amore.Domain.Data.Model;

namespace Amore.Domain.Order
{
    /// <summary>
    /// Service for ordering pizzas
    /// </summary>
    public interface IAmoreOrderService
    {
        /// <summary>
        /// Orders a pizza with added goodies
        /// </summary>
        /// <param name="pizza"></param>
        /// <param name="goodies"></param>
        void PutOrder(Pizza pizza, IEnumerable<Goodie> goodies);

        /// <summary>
        /// Finishes the current order
        /// </summary>
        void Checkout();

        /// <summary>
        /// Retrieves info about the current order session
        /// </summary>
        /// <returns></returns>
        Task<CompleteOrderInfo> GetOrderInfo();

        /// <summary>
        /// Opens a new order session
        /// </summary>
        /// <returns>if a new session has been opened</returns>
        Task<bool> OpenSession();

        /// <summary>
        /// Closes the current order session
        /// </summary>
        void CloseSession();
    }
}