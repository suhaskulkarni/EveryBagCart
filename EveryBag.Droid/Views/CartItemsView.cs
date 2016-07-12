using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Droid.Views;
using Android.OS;
using Android.Widget;
using Android.App;
using Android.Graphics;
using MvvmCross.Binding.Droid.Views;

namespace EveryBag.Droid.Views
{
	[Activity(MainLauncher = false)]
	public class CartItemsView : MvxActivity
	{
        /// <summary>
        /// The OnCreate method.
        /// </summary>
        /// <param name="bundle"></param>
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Window.AddFlags (Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
			var color = new Color (62, 160,205);
			Window.SetStatusBarColor (color);
			ActionBar.Hide ();
			SetContentView (Resource.Layout.CartItemsView);

		}

	}
}

