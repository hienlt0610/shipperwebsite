using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShipperWebsite.Models.ShipperAdmin;
using ShipperWebsite.Controllers;


namespace ShipperWebsite.Controllers
{
    public class BaseController : Controller
    {
        protected bool CheckLogin { get; set; }
        public BaseController()
        {
            CheckLogin = true;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CheckLogin) {
                var sess = (UserAdmin)Session[Constants.USER_SESSION];
                if (sess == null)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index" }));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
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