using EveryBag.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryBag.Core.Interfaces
{
    public interface ICartItemDetailService
    {
        /// <summary>
        /// Gets or sets the list of cart item details.
        /// </summary>
        List<CartItemDetailModel> CartItemDetail { get; set; }
    }
}
