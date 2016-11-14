using Newtonsoft.Json;
using ShipperWebsite.FirebaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            var usersChild = FirebaseClient.Get("users");
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
	}
}