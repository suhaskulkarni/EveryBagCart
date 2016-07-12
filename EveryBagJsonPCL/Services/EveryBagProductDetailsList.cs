using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EveryBagLibrary.JsonClasses;
using System.Net;
using EveryBagLibrary.Constants;
using Newtonsoft.Json;
using EveryBagLibrary.Interfaces;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EveryBagLibrary.Services
{
    public class EveryBagProductDetailsList : IEveryBagProductDetailsList
    {
        /// <summary>
        /// Gets or sets the list of product details in a cart.
        /// </summary>
        public List<ProductDetails> ProductDetailsList { get; set; }

        /// <summary>
        /// Gets the list of product details in the cart.
        /// </summary>
        /// <returns></returns>
        public async Task GetProductDetailsList()
        {
            string jsonResponse;
            using (HttpClient client = new HttpClient())
            {
                jsonResponse = await client.GetStringAsync(EveryBagConstants.CartJsonUrl);
            }

            JObject jsonProductsString = JObject.Parse(jsonResponse);
            var productsList = jsonProductsString[EveryBagConstants.JsonProducts];

            ProductDetailsList = JsonConvert.DeserializeObject<List<ProductDetails>>(productsList.ToString());
        }
    }
}