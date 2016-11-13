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

        public ActionResult Edit()
        {

        }
	}
}