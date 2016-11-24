using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShipperWebsite.FirebaseModel
{
    public class Order
    {
        public Order()
        {
            Sender = new Customer();
            Receiver = new Customer();
        }
        [JsonProperty(PropertyName = "orderID")]
        public String OrderID { get; set; }

        [JsonProperty(PropertyName = "sender")]
        public Customer Sender { get; set; }

        [JsonProperty(PropertyName = "receiver")]
        public Customer Receiver { get; set; }

        [JsonProperty(PropertyName = "status")]
        public bool Status { get; set; }

        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "userID")]
        public String UserID { get; set; }

        [JsonProperty(PropertyName = "totalPrice")]
        public long TotalPrice { get; set; }
    }
}