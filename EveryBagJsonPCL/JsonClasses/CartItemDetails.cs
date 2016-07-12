using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace EveryBagLibrary.JsonClasses
{
    public class CartItemDetails
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("price")]
        public int price { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }

        [JsonProperty("pid")]
        public string pid { get; set; }

        [JsonProperty("oid")]
        public string oid { get; set; }

        [JsonProperty("count")]
        public int count { get; set; }
    }
}