using Newtonsoft.Json;
using ShipperWebsite.FirebaseModel;
using ShipperWebsite.FirebaseModel.FirebaseMessage;
using ShipperWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShipperWebsite.core;

namespace ShipperWebsite.Controllers
{
    public class StaffController : BaseController
    {
        public StaffController()
        {
            CheckLogin = false;
        }
        //
        // GET: /Staff/
        public async Task<ActionResult> Index()
        {
            var usersChild = await FirebaseClient.GetTaskAsync("users");
            var users = usersChild.ResultAs<Dictionary<String, User>>();
            var model = users.Select(u => new User { 
                UserID = u.Key,
                Email = u.Value.Email,
                FullName = u.Value.FullName,
                Phone = u.Value.Phone,
                ProfilePicture = u.Value.ProfilePicture
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            if(id == null){
                return new HttpNotFoundResult();
            }
            var userChild = FirebaseClient.Get("users/"+id);
            var model = userChild.ResultAs<User>();
            if (model == null) return new HttpNotFoundResult();
            model.UserID = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var newUpdate = new
            {
                fullName = user.FullName,
                phone = user.Phone
            };
            FirebaseClient.Update("users/" + user.UserID, newUpdate);

            return RedirectToAction("Index","Staff");
        }

       
        public ActionResult Contact(String id)
        {
            if(id == null) return new HttpNotFoundResult();
            var userChild = FirebaseClient.Get("users/"+id);
            var user = userChild.ResultAs<User>();
            if (user == null) return new HttpNotFoundResult();
            user.UserID = id;
            ViewBag.User = user;
            var model = new StaffContactViewModel();
            model.UserId = user.UserID;
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(StaffContactViewModel model)
        {
            if(ModelState.IsValid){
                FMessage message = new FMessage(model.UserId);
                message.Title = model.Title;
                message.Message = model.Message;
                var content = FirebaseClient.PushNotification("global",message);
                return RedirectToAction("Index","Staff");
            }
            var userChild = FirebaseClient.Get("users/" + model.UserId);
            var user = userChild.ResultAs<User>();
            ViewBag.User = user;
            return View(model);
        }
	}
}