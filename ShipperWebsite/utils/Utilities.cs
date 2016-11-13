using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShipperWebsite.utils
{
    public static class Utilities
    {
        public static string IsActive(this HtmlHelper html,
                                      string action,
                                      string controller)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = controller == routeControl &&
                               action == routeAction;

            return returnActive ? "active" : "";
        }
    }
}