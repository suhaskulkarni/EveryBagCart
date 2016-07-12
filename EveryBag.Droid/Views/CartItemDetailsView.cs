using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Droid.Views;
using Android.OS;
using Android.App;
using EveryBag.Core.ViewModels;
using Android.Views;
using System.Runtime.Remoting.Contexts;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using Android.Content;
using Android.Util;
using EveryBag.Core.DataModel;
using System.Collections.ObjectModel;
using EveryBag.Droid.Adapters;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace EveryBag.Droid.Views
{
	[Activity(MainLauncher = false)]
	public class CartItemDetailsView : MvxActivity
	{
		ListView listview = null;

        /// <summary>
        /// The OnCreate method.
        /// </summary>
        /// <param name="bundle"></param>
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);
			Window.AddFlags (Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
			var color = new Color (62, 160,205);
			Window.SetStatusBarColor (color);

            SetContentView(Resource.Layout.CartItemDetailsView);
			listview = FindViewById<ListView>(Resource.Id.CartItemsList);

            var footer = this.BindingInflate(Resource.Layout.cart_total, null);

            listview.AddFooterView(footer);

            List<CartItemDetailModel> cartDetailModel = new List<CartItemDetailModel>();
            foreach(var item in (this.ViewModel as CartItemDetailsViewModel).CartItemDetail)
            {
                cartDetailModel.Add(item);
            }

			listview.Adapter = new CustomAdapter(this, cartDetailModel);

			ActionBar.SetDisplayShowHomeEnabled(false);
			ActionBar.SetDisplayShowTitleEnabled(false);

			ActionBar.SetCustomView (Resource.Layout.cart_detail_actionbar);
			ActionBar.SetDisplayShowCustomEnabled (true);

			Toolbar parent = (Toolbar)ActionBar.CustomView.Parent;
			parent.SetContentInsetsAbsolute (0, 0);

			FindViewById<TextView> (Resource.Id.CartTitleBarName).Text = (this.ViewModel as CartItemDetailsViewModel).CartTitle;

			FindViewById<ImageButton> (Resource.Id.BackButton).Click += BackButtonClick;
		}

        /// <summary>
        /// The back button click handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public void BackButtonClick(object sender, EventArgs e)
		{
			OnBackPressed ();
		}
	}
}

