using FireSharp.Response;
using Newtonsoft.Json;
using RestSharp;
using ShipperWebsite.FirebaseModel;
using ShipperWebsite.utils;
using ShipperWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShipperWebsite.core;
using ShipperWebsite.FirebaseModel.FirebaseMessage;

namespace ShipperWebsite.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController()
        {
            CheckLogin = false;
        }
        //
        // GET: /Order/
        public async Task<ActionResult> Index()
        {
            //FirebaseResponse response = await FirebaseClient.GetAsync("orders");
            try
            {
                var response = await FirebaseClient.GetTaskAsync("orders");
                var orders = response.ResultAs<Dictionary<String, Order>>();

                var model = orders.Select(u => new Order
                {
                    OrderID = u.Key,
                    UserID = u.Value.UserID,
                    Status = u.Value.Status,
                    Time = u.Value.Time,
                    Receiver = u.Value.Receiver,
                    Sender = u.Value.Sender,
                    TotalPrice = u.Value.TotalPrice,
                }).ToList();
                return View(model);
            }
            catch (Exception e)
            {
            }
            return View(new List<Order>());
        }

        public ActionResult Add()
        {
            var resUser = FirebaseClient.Get("users");
            var users = resUser.ResultAs<Dictionary<String, User>>();
            var modelUser = users.Select(u => new User
            {
                UserID = u.Key,
                Email = u.Value.Email,
                FullName = u.Value.FullName,
                Phone = u.Value.Phone,
                ProfilePicture = u.Value.ProfilePicture,
            }).ToList();
            ViewBag.Users = modelUser;
            return View(new OrderViewModel());
        }

        [HttpPost]
        public ActionResult Add(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order();
                order.Time = TimeUtils.ConvertToTimestamp(DateTime.Now);
                order.Sender.FullName = model.SenderFullName;
                order.Sender.Address = model.SenderAddress;
                order.Sender.Phone = model.SenderPhone;
                order.Sender.Lat = model.SenderLatLng.Lat;
                order.Sender.Lng = model.SenderLatLng.Lng;
                order.Receiver.FullName = model.ReceiveFullName;
                order.Receiver.Address = model.ReceiveAddress;
                order.Receiver.Phone = model.ReceivePhone;
                order.Receiver.Lat = model.ReceiveLatLng.Lat;
                order.Receiver.Lng = model.ReceiveLatLng.Lng;
                order.TotalPrice = model.TotalPrice;
                order.UserID = model.UserID;
                order.Status = false;
                FirebaseClient.PushTaskAsync("orders", order);

                //Push notification to user
                FMessage FMessage = new FMessage(order.UserID);
                FMessage.Title = "Nhận được hàng mới";
                FMessage.Message = "Bạn vừa được tiếp nhận một đơn hàng mới";
                FirebaseClient.PushNotification("global", FMessage);

                return RedirectToAction("Index", "Order");
            }
            var resUser = FirebaseClient.Get("users");
            var users = resUser.ResultAs<Dictionary<String, User>>();
            var modelUser = users.Select(u => new User
            {
                UserID = u.Key,
                Email = u.Value.Email,
                FullName = u.Value.FullName,
                Phone = u.Value.Phone,
                ProfilePicture = u.Value.ProfilePicture,
            }).ToList();
            ViewBag.Users = modelUser;
            return View(model);
        }

    }
}