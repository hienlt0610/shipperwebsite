using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipperWebsite.FirebaseModel.FirebaseMessage
{
    public class FMessage
    {
        public FMessage(String userID)
        {
            this.UserId = userID;
        }
        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}