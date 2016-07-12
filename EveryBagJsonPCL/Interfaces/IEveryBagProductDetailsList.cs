using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EveryBagLibrary.JsonClasses;
using System.Threading.Tasks;

namespace EveryBagLibrary.Interfaces
{
    public interface IEveryBagProductDetailsList
    {
        /// <summary>
        /// Details of a product such as name, price, id.
        /// </summary>
        List<ProductDetails> ProductDetailsList { get; set; }

        /// <summary>
        /// Gets the list of product details.
        /// </summary>
        /// <returns></returns>
        Task GetProductDetailsList();
    }
}