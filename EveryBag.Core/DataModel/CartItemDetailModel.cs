using EveryBag.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryBag.Core.DataModel
{
    public class CartItemDetailModel
    {
        /// <summary>
        /// Image Url.
        /// </summary>
        private string _imageUrl;

        /// <summary>
        /// The image Url.
        /// </summary>
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
            }
        }

        /// <summary>
        /// Item title.
        /// </summary>
        private string _itemTitle;

        /// <summary>
        /// The item title.
        /// </summary>
        public string ItemTitle
        {
            get
            {
                return _itemTitle;
            }
            set
            {
                _itemTitle = value;
            }
        }

        /// <summary>
        /// Item price.
        /// </summary>
        private string _itemPrice;
        
        /// <summary>
        /// The item price.
        /// </summary>
        public string ItemPrice
        {
            get
            {
                return _itemPrice;
            }
            set
            {
                _itemPrice = value;
            }
        }

        /// <summary>
        /// Item sold by text fetched from constant string.
        /// </summary>
		public string ItemSoldByText
		{
			get 
			{
				return Constants.SoldByText;
			}
		}

        /// <summary>
        /// Name of the seller.
        /// </summary>
		public string ItemSoldByName
		{
			get 
			{
				return Constants.MingaBerlinText;
			}
		}
    }
}
