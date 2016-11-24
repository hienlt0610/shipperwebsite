using ShipperWebsite.FirebaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShipperWebsite.ViewModel
{
    public class OrderViewModel
    {
        public String OrderID { get; set; }

        [Required]
        public String SenderFullName { get; set; }

        [Required]
        public String SenderAddress { get; set; }

        [Required]
        public String SenderPhone { get; set; }

        public LatLng SenderLatLng { get; set; }

        [Required]
        public String ReceiveFullName { get; set; }

        [Required]
        public String ReceiveAddress { get; set; }

        [Required]
        public String ReceivePhone { get; set; }

        public LatLng ReceiveLatLng { get; set; }

        [Required]
        public long TotalPrice { get; set; }

        [Required]
        public String UserID { get; set; }
    }
}