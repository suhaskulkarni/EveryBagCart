using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EveryBagLibrary.JsonClasses;
using System.Threading.Tasks;

namespace EveryBagLibrary.Interfaces
{
    public interface IEveryBagCartItemsList
    {
        /// <summary>
        /// List of cart items
        /// </summary>
        List<CartItems> CartItemsList { get; set; }

        /// <summary>
        /// Gets the list of cart items asynchronously
        /// </summary>
        /// <returns></returns>
        Task GetCartItemsList();
    }
}