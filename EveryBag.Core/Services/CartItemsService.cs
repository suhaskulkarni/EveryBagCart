using System;
using EveryBag.Core.Interfaces;
using EveryBag.Core.DataModel;
using EveryBagLibrary.Interfaces;
using EveryBagLibrary.Services;
using EveryBagLibrary.JsonClasses;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using EveryBag.Core.Common;

namespace EveryBag.Core.Services
{
    public class CartItemsService : ICartItemsService
    {
        /// <summary>
        /// Everybag cart items interface member.
        /// </summary>
        public IEveryBagCartItemsList EveryBagCartItems { get; set; }

        /// <summary>
        /// EveryBag product product details interface member.
        /// </summary>
        public IEveryBagProductDetailsList EveryBagProductDetails { get; set; }

        /// <summary>
        /// Gets the list of cart items.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CartItemModel>> GetCartItemsAsync()
        {
            EveryBagCartItems = new EveryBagCartItemsList();
            EveryBagProductDetails = new EveryBagProductDetailsList();

            await EveryBagCartItems.GetCartItemsList();
            await EveryBagProductDetails.GetProductDetailsList();

            return getCartItemsList();
        }

        /// <summary>
        /// Goes through EveryBag product details and cart list to get the cart items list.
        /// </summary>
        /// <returns></returns>
        private List<CartItemModel> getCartItemsList()
        {
            List<CartItemModel> cartItemModelList = new List<CartItemModel>();
            foreach (var item in EveryBagCartItems.CartItemsList)
            {
                CartItemModel CartItem = new CartItemModel();

                CartItem.CartImage1 = EveryBagProductDetails.ProductDetailsList.Where(x => x.id == item.items.FirstOrDefault().pid).FirstOrDefault().imageUrl;
                if (item.items.Count > 1)
                {
                    CartItem.CartImage2 = EveryBagProductDetails.ProductDetailsList.Where(x => x.id == item.items.ElementAt(1).pid).FirstOrDefault().imageUrl;
                }

                CartItem.CartId = item.id;
                CartItem.CartItemName = item.name;
                CartItem.CartItemsTotal = item.items.Count.ToString() + " Items";
                CartItem.CartItemsPrice = item.items.FirstOrDefault().currency + " " + item.items.Sum(x => x.price).ToString() + " Total";
                CartItem.CartUpdate = Constants.UpdateText;

                CartItem.PidList = item.items.Select(x => x.pid).ToList();

                cartItemModelList.Add(CartItem);
            }

            return cartItemModelList;
        }

        /// <summary>
        /// Gets the cart item details based on the product Id list.
        /// </summary>
        /// <param name="pidList"></param>
        /// <returns></returns>
		public List<CartItemDetailModel> GetCartItemDetailModelList(List<string> pidList)
        {
            List<CartItemDetailModel> cartDetails = new List<CartItemDetailModel>();
            foreach (var pid in pidList)
            {
                CartItemDetailModel cartItemDetail = new CartItemDetailModel();
                cartItemDetail.ImageUrl = EveryBagProductDetails.ProductDetailsList.Where(x => x.id == pid).FirstOrDefault().imageUrl;
                foreach (var item in EveryBagCartItems.CartItemsList)
                {
                    if (item.items.Any(x => x.pid == pid))
                    {
						cartItemDetail.ItemPrice = Constants.CurrencyText + string.Format("{0,0:N2}", item.items.Where(x => x.pid == pid).FirstOrDefault().price);
                    }
                }
				string[] title = EveryBagProductDetails.ProductDetailsList.Where(x => x.id == pid).FirstOrDefault().title.Split('-');
				cartItemDetail.ItemTitle = string.Join ("-", title.Take (2));
                cartDetails.Add(cartItemDetail);
            }

            return cartDetails;
        }
    }
}

