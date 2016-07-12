using EveryBag.Core.DataModel;
using EveryBag.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryBag.Core.Services
{
    public class CartItemDetailService : ICartItemDetailService
    {
        /// <summary>
        /// Cart item service interface member.
        /// </summary>
        private readonly ICartItemsService _cartItemsService;

        /// <summary>
        /// Cart Item detail service Constructor.
        /// </summary>
        /// <param name="cartItemsService">Injected property.</param>
        public CartItemDetailService(ICartItemsService cartItemsService)
        {
            this._cartItemsService = cartItemsService;
        }

        /// <summary>
        /// Gets or sets the list of cart item details.
        /// </summary>
        public List<CartItemDetailModel> CartItemDetail { get; set; }

        /// <summary>
        /// Gets the list of cart item details.
        /// </summary>
        /// <param name="pidList">The list of product Ids.</param>
        /// <returns>Returns list of cart item detail.</returns>
        public List<CartItemDetailModel> GetCartItemDetail(List<string> pidList)
        {
            List<CartItemDetailModel> cartItemDetailModelList = new List<CartItemDetailModel>();
            if (_cartItemsService.EveryBagCartItems != null && _cartItemsService.EveryBagProductDetails != null)
            {
                foreach(var id in pidList)
                {
                    CartItemDetailModel cartItemDetailModel = new CartItemDetailModel();
                    cartItemDetailModel.ImageUrl = _cartItemsService.EveryBagProductDetails.ProductDetailsList.Where(x => x.id == id).FirstOrDefault().imageUrl;
                    cartItemDetailModel.ItemTitle = _cartItemsService.EveryBagProductDetails.ProductDetailsList.Where(x => x.id == id).FirstOrDefault().title;
					cartItemDetailModel.ItemPrice = _cartItemsService.EveryBagCartItems.CartItemsList.Select(x => x.items.Where(y => y.pid == id).FirstOrDefault().price).FirstOrDefault().ToString();
                    cartItemDetailModelList.Add(cartItemDetailModel);
                }
            }

            return cartItemDetailModelList;
        }
    }
}
