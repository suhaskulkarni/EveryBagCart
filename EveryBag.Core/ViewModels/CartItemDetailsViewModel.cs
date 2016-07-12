using System;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using EveryBag.Core.Interfaces;
using EveryBag.Core.DataModel;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using MvvmCross.Platform;
using System.Linq;
using EveryBag.Core.Common;

namespace EveryBag.Core.ViewModels
{
	public class CartItemDetailsViewModel : MvxViewModel
	{
        /// <summary>
        /// Cart item service.
        /// </summary>
		private ICartItemsService _cartItemsService;

        /// <summary>
        /// Cart item detail service.
        /// </summary>
        private ICartItemDetailService _cartItemDetailService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cartItemsService"></param>
        /// <param name="cartItemDetailService"></param>
		public CartItemDetailsViewModel (ICartItemsService cartItemsService, ICartItemDetailService cartItemDetailService)
		{
            _cartItemsService = cartItemsService;
            _cartItemDetailService = cartItemDetailService;
		}

        /// <summary>
        /// Cart item detail.
        /// </summary>
        private ObservableCollection<CartItemDetailModel> _cartItemDetail;

        /// <summary>
        /// Binded Cart item detail collection.
        /// </summary>
        public ObservableCollection<CartItemDetailModel> CartItemDetail
        {
            get
            {
                return _cartItemDetail;
            }
            set
            {
                _cartItemDetail = value;
                RaisePropertyChanged(() => CartItemDetail);
            }
        }

        /// <summary>
        /// Cart sub total.
        /// </summary>
		private string _cartSubTotal;

        /// <summary>
        /// Binded Cart sub total.
        /// </summary>
		public string CartSubTotal
		{
			get 
			{
				return _cartSubTotal;
			}
			set 
			{
				_cartSubTotal = value;
			}
		}

        /// <summary>
        /// Place item will be shipped to.
        /// </summary>
		private string _shippingPlace;

        /// <summary>
        /// Binded place item will be shipped to.
        /// </summary>
		public string ShippingPlace
		{
			get
			{
				return _shippingPlace;
			}
			set
			{
				_shippingPlace = value;
			}
		}

        /// <summary>
        /// Cost of shipping.
        /// </summary>
		private string _shippingCost;

        /// <summary>
        /// Binded cost of shipping.
        /// </summary>
		public string ShippingCost
		{
			get
			{
				return _shippingCost;
			}
			set 
			{
				_shippingCost = value;
			}
		}

        /// <summary>
        /// Promo discount.
        /// </summary>
		private string _promoDiscount;

        /// <summary>
        /// Binded promo discount.
        /// </summary>
		public string PromoDiscount
		{
			get
			{
				return _promoDiscount;
			}
			set 
			{
				_promoDiscount = value;
			}
		}

        /// <summary>
        /// Inclusive taxes.
        /// </summary>
		private string _incTaxes;

        /// <summary>
        /// Binded inclusive taxes.
        /// </summary>
		public string IncTaxes
		{
			get 
			{
				return _incTaxes;
			}
			set 
			{
				_incTaxes = value;
			}
		}

        /// <summary>
        /// The total amount.
        /// </summary>
		private string _totalAmount;

        /// <summary>
        /// Binded total amount.
        /// </summary>
		public string TotalAmount
		{
			get 
			{
				return _totalAmount;
			}
			set 
			{
				_totalAmount = value;
			}
		}

        /// <summary>
        /// The cart title.
        /// </summary>
		private string _cartTitle;

        /// <summary>
        /// The binded cart title.
        /// </summary>
		public string CartTitle
		{
			get 
			{
				return _cartTitle;
			}
			set 
			{
				_cartTitle = value;
			}
		}

        /// <summary>
        /// The Init method which is fired when navigated. Has the navigation parameters.
        /// </summary>
        /// <param name="param">Json string parameters which needs to be deserialized.</param>
        public void Init(string param)
        {
            CartItemDetail = new ObservableCollection<CartItemDetailModel>();

            var deserializedJson = JsonConvert.DeserializeObject<CartItemModel>(param);
			var cartItemDetailList = _cartItemsService.GetCartItemDetailModelList(deserializedJson.PidList);

            foreach (var item in cartItemDetailList)
            {
                CartItemDetail.Add(item);
            }

			CartSubTotal = Constants.CurrencyText + string.Format("{0,0:N2}", CartItemDetail.Sum (x => Convert.ToDouble(x.ItemPrice.Substring(1))));

			ShippingPlace = Constants.ShippingPlaceText;
			ShippingCost = Constants.CurrencyText + string.Format ("{0,0:N2}", Constants.ShippingPrice);
			PromoDiscount = Constants.DiscountText + Constants.CurrencyText + string.Format ("{0,0:N2}", Convert.ToDouble(CartSubTotal.Substring(1))/2);
			IncTaxes = Constants.IncTaxText + ShippingCost + Constants.TaxesText;

			TotalAmount = Constants.CurrencyText + string.Format ("{0,0:N2}", Convert.ToDouble(CartSubTotal.Substring(1)) + Convert.ToDouble(ShippingCost.Substring(1)) - Convert.ToDouble(PromoDiscount.Substring(2)));

			CartTitle = deserializedJson.CartItemName;
        }
    }
}

