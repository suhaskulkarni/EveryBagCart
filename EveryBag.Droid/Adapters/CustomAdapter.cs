using System;
using MvvmCross.Binding.Droid.Views;
using Android.Content;
using MvvmCross.Binding.Droid.BindingContext;
using System.Collections.Generic;
using Android.Widget;
using System.Collections;
using Android.Views;
using Android.Util;
using MvvmCross.Binding.Attributes;
using EveryBag.Core.DataModel;
using Java.Lang;
using Android.App;

namespace EveryBag.Droid.Adapters
{
    public class CustomAdapter : BaseAdapter<CartItemDetailModel>
    {
        /// <summary>
        /// The current activity context.
        /// </summary>
        private Activity context;

        /// <summary>
        /// The cart item detail list.
        /// </summary>
        private List<CartItemDetailModel> cartItemDetailModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
		public CustomAdapter(Activity context, List<CartItemDetailModel> model)
        {
            this.context = context;
            this.cartItemDetailModel = model;
        }

        /// <summary>
        /// The count of items.
        /// </summary>
        public override int Count
        {
            get
            {
                return cartItemDetailModel.Count;
            }
        }

        /// <summary>
        /// The current position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override CartItemDetailModel this[int position]
        {
            get
            {
                return cartItemDetailModel[position];
            }
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// Creates and gets the view.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate(Resource.Layout.cart_item_detail, parent, false);

            CartItemDetailModel item = this[position];
            view.FindViewById<MvxImageView>(Resource.Id.CartDetailImage).ImageUrl = item.ImageUrl;
            view.FindViewById<TextView>(Resource.Id.CartDetailTitle).Text = item.ItemTitle;
            view.FindViewById<TextView>(Resource.Id.SoldByTitle).Text = item.ItemSoldByText;
            view.FindViewById<TextView>(Resource.Id.SoldByName).Text = item.ItemSoldByName;
            view.FindViewById<TextView>(Resource.Id.CartDetailPrice).Text = item.ItemPrice;

            return view;
        }
    }
}

