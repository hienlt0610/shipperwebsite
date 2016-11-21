using Newtonsoft.Json;
using ShipperWebsite.FirebaseModel;
using ShipperWebsite.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShipperWebsite.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(){
            CheckLogin = false;
        }
        //
        // GET: /Order/
        public ActionResult Index()
        {
            var orderChild = FirebaseClient.Get("orders");
            var orders = orderChild.ResultAs<Dictionary<String, Order>>();
            var model = orders.Select(u => new Order
            {
                OrderID = u.Key,
                UserID = u.Value.UserID,
                Status = u.Value.Status,
                Time = u.Value.Time
            }).ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            return View(new Order());
        }

        [HttpPost]
        public ActionResult Add(Order model)
        {
            model.Time = TimeUtils.ConvertToTimestamp(DateTime.Now);
            FirebaseClient.PushAsync("orders",model);
            return RedirectToAction("Index","Order");
        }
	}
}