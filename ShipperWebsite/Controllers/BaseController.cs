using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShipperWebsite.Controllers
{
    public class BaseController : Controller
    {
        protected IFirebaseClient FirebaseClient { get; set; }
        public BaseController()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "3Vng3ivH9gEkCpbDqdDuVBllRmjDwKIi4JyLx8gp",
                BasePath = "https://shippermanager-9752c.firebaseio.com/"
            };
            FirebaseClient = new FirebaseClient(config);
        }
	}
}