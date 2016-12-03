
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipperWebsite.FirebaseModel
{
    public class Presences
    {
        [JsonProperty(PropertyName = "lastSeen")]
        public long LastSeen{get;set;}

        [JsonProperty(PropertyName = "status")]
        public String Status { get; set; }

        [JsonIgnore]
        public bool isOnline
        {
            get
            {
                return this.Status.Equals("online");
            }
        }

    }
}