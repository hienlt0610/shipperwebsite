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
}