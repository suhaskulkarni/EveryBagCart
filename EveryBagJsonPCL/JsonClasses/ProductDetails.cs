using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace EveryBagLibrary.JsonClasses
{
    public class ProductDetails
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("desc")]
        public string desc { get; set; }

        [JsonProperty("var")]
        public VariableSize var { get; set; }

        [JsonProperty("imageUrl")]
        public string imageUrl { get; set; }
    }

    public class VariableSize
    {
        [JsonProperty("size")]
        public string size { get; set; }
    }
}