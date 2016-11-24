using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShipperWebsite.ViewModel
{
    public class StaffContactViewModel
    {
        public String UserId { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Message { get; set; }
    }
}