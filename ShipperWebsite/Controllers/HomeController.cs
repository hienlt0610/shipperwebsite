using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShipperWebsite.FirebaseModel;
using ShipperWebsite.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShipperWebsite.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var orderChild = await FirebaseClient.GetTaskAsync("orders");
            var orders = orderChild.ResultAs<Dictionary<String, Order>>();
            if(orders == null){
                ViewBag.OrderCount = 0;
            }
            else
            {
                ViewBag.OrderCount = orders.Count;
            }


            var userChild = await FirebaseClient.GetTaskAsync("users");
            var users = userChild.ResultAs<Dictionary<String, User>>();
            if (users == null)
            {
                ViewBag.UserCount = 0;
            }
            else
            {
                ViewBag.UserCount = users.Count;
            }

            var presencesChild = await FirebaseClient.GetTaskAsync("presences");
            var presences = presencesChild.ResultAs<Dictionary<String, Presences>>();
            if (presences == null)
            {
                ViewBag.PresencesCount = 0;
            }
            else
            {
                int count = presences.Where(t => t.Value.isOnline).Count();
                ViewBag.PresencesCount = count;
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            FirebaseResponse response = FirebaseClient.Get("users");
            var users = response.ResultAs<IDictionary<string, User>>();
            return Content(JsonConvert.SerializeObject(users), "application/json");
        }
    }
}