using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Graphics;

namespace EveryBag.Droid.Views
{
    [Activity(MainLauncher = true, Theme="@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class LoginPageView : MvxActivity
    {
		private EditText UserNameText = null;
		private EditText PasswordText = null;
		private Button LoginButton = null;

        /// <summary>
        /// The OnCreate method.
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginPageView);

            UserNameText = FindViewById<EditText>(Resource.Id.Username);
            PasswordText = FindViewById<EditText>(Resource.Id.Password);
            LoginButton = FindViewById<Button>(Resource.Id.LoginInButton);

            UserNameText.AfterTextChanged += EnableLoginButton;
            PasswordText.AfterTextChanged += EnableLoginButton;

            LoginButton.Click += LoginButtonClick;
        }

        /// <summary>
        /// The Username and password fields text changed handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EnableLoginButton(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserNameText.Text) && !(string.IsNullOrWhiteSpace(PasswordText.Text)))
            {
                var color = new Color(62, 160, 205);
                LoginButton.SetBackgroundColor(color);
                LoginButton.Enabled = true;
            }
            else
            {
                var color = new Color(181, 181, 181);
                LoginButton.SetBackgroundColor(color);
                LoginButton.Enabled = false;
            }
        }

        /// <summary>
        /// The login button handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoginButtonClick(object sender, EventArgs e)
        {
            StartActivity(typeof(CartItemsView));
        }
    }
}