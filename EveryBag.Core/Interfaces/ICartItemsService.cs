using System;
using EveryBag.Core.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using EveryBagLibrary.Interfaces;

namespace EveryBag.Core.Interfaces
{
	public interface ICartItemsService
	{
        /// <summary>
        /// Gets or sets the Every bag cart items list member.
        /// </summary>
        IEveryBagCartItemsList EveryBagCartItems { get; set; }

        /// <summary>
        /// Gets or sets the every bag product details list member.
        /// </summary>
        IEveryBagProductDetailsList EveryBagProductDetails { get; set; }

        /// <summary>
        /// Gets the list of Cart Items.
        /// </summary>
        /// <returns></returns>
        Task<List<CartItemModel>> GetCartItemsAsync ();

        /// <summary>
        /// Gets the list of cart item details based on the Product id list.
        /// </summary>
        /// <param name="pidList">The list of product Ids.</param>
        /// <returns>List of cart item details.</returns>
		List<CartItemDetailModel> GetCartItemDetailModelList(List<string> pidList);

    }
}

