using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryBag.Core.ViewModels
{
    public class LoginPageViewModel: MvxViewModel
    {
        /// <summary>
        /// The user name.
        /// </summary>
        private string _username;

        /// <summary>
        /// Binded user name.
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        /// <summary>
        /// The password.
        /// </summary>
        private string _password;

        /// <summary>
        /// Binded password.
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
    }
}
