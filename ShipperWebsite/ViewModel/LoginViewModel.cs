using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShipperWebsite.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Vui lòng nhập tài khoản")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập password")]
        [StringLength(50)]
        public string Password_ { get; set; }
    }
}