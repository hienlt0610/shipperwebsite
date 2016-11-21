using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipperWebsite.FirebaseModel
{
    public class Customer
    {
        [JsonProperty(PropertyName="fullName")]
        public String FullName { get; set; }

        [JsonProperty(PropertyName = "address")]
        public String Address { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Lat { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public double Lng { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public String Phone { get; set; }
    }
}