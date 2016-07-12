using EveryBagLibrary.Interfaces;
using EveryBagLibrary.JsonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using EveryBagLibrary.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EveryBagLibrary.Services
{
    public class EveryBagCartItemsList : IEveryBagCartItemsList
    {
        /// <summary>
        /// List of cart items property.
        /// </summary>
        public List<CartItems> CartItemsList { get; set; }

        /// <summary>
        /// Implementation of getting the cart items list.
        /// </summary>
        /// <returns></returns>
        public async Task GetCartItemsList()
        {
            string jsonResponse;

            using (HttpClient client = new HttpClient())
            {
                jsonResponse = await client.GetStringAsync(EveryBagConstants.CartJsonUrl);
            }

            JObject jsonCartsString = JObject.Parse(jsonResponse);
            var cartsList = jsonCartsString[EveryBagConstants.JsonCarts];

            CartItemsList = JsonConvert.DeserializeObject<List<CartItems>>(cartsList.ToString());
        }
    }
}
