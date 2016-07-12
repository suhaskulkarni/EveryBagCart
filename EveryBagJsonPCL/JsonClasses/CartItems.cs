using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace EveryBagLibrary.JsonClasses
{
    public class CartItems
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("userId")]
        public string userId { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("items")]
        public List<CartItemDetails> items { get; set; }

        [JsonProperty("status")]
        public int status { get; set; }

        [JsonProperty("etag")]
        public string etag { get; set; }
    }
}