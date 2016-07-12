using System;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using EveryBag.Core.DataModel;
using EveryBag.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace EveryBag.Core.ViewModels
{
    public class CartItemsViewModel : MvxViewModel
    {
        /// <summary>
        /// The cart item service.
        /// </summary>
        private ICartItemsService _cartItemsService;

        /// <summary>
        /// The cart list item click command.
        /// </summary>
		private IMvxCommand _cartItemClick;

        /// <summary>
        /// The Cart list item click command handled.
        /// </summary>
		public IMvxCommand CartItemClickCommand
		{
			get 
			{
				_cartItemClick = _cartItemClick ?? new MvxCommand<CartItemModel> (SelectCartItem);
				return _cartItemClick;
			}
		}

        /// <summary>
        /// Collection of cart items.
        /// </summary>
        private ObservableCollection<CartItemModel> _cartItems;

        /// <summary>
        /// Binded collection of cart items.
        /// </summary>
        public ObservableCollection<CartItemModel> CartItems
        {
            get
            {
                return _cartItems;
            }
            set
            {
				_cartItems = value;
                RaisePropertyChanged(() => CartItems);
            }
        }

		private bool _isLoading;
		public bool IsLoading
		{
			get
			{
				return _isLoading;
			}
			set 
			{
				_isLoading = value;
				RaisePropertyChanged (() => IsLoading);
			}
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cartItemsService"></param>
        public CartItemsViewModel(ICartItemsService cartItemsService)
        {
            this._cartItemsService = cartItemsService;
            this.PageLoad();
        }

        /// <summary>
        /// Loads the page asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task PageLoad()
        {
			IsLoading = true;

            CartItems = new ObservableCollection<CartItemModel>();

            List<CartItemModel> cartItemModelList = new List<CartItemModel>();
            cartItemModelList = await _cartItemsService.GetCartItemsAsync();

            foreach (var cartItemModel in cartItemModelList)
            {
                CartItems.Add(cartItemModel);
            }

			IsLoading = false;
        }

        /// <summary>
        /// Selected cart item handler.
        /// </summary>
        /// <param name="model"></param>
		private void SelectCartItem(CartItemModel model)
		{
            string jsonData = JsonConvert.SerializeObject(model);
			ShowViewModel<CartItemDetailsViewModel> (new { param = jsonData});
		}
    }
}

