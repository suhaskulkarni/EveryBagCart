using System;
using System.Collections.Generic;

namespace EveryBag.Core.DataModel
{
	public class CartItemModel
	{
        /// <summary>
        /// The cart item name.
        /// </summary>
		public string CartItemName{ get; set; }

        /// <summary>
        /// The total number of items in cart.
        /// </summary>
		public string CartItemsTotal{ get; set; }

        /// <summary>
        /// The total price of the cart.
        /// </summary>
		public string CartItemsPrice{ get; set; }

        /// <summary>
        /// Cart first image.
        /// </summary>
        public string CartImage1 { get; set; }

        /// <summary>
        /// Cart second image to be displayed.
        /// </summary>
        public string CartImage2 { get; set; }

        /// <summary>
        /// The latest updated cart.
        /// </summary>
		public string CartUpdate { get; set; }

        /// <summary>
        /// The cart Id.
        /// </summary>
		public string CartId { get; set; }

        /// <summary>
        /// The list of Product Ids.
        /// </summary>
        public List<string> PidList { get; set; }
    }
}

