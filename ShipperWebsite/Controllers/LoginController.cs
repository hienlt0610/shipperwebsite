using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShipperWebsite.Models.DataAccess;
using ShipperWebsite.Models.ShipperAdmin;
using ShipperWebsite.ViewModel;

namespace ShipperWebsite.Controllers
{
    public class LoginController : BaseController
    {

        public LoginController()
        {
            CheckLogin = false;
        }

        [HttpGet]
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid) {
                UserDAO userDAO = new UserDAO();
                UserAdmin user = userDAO.Login(model.UserName, model.Password_);
                if (user != null)
                {
                    Session["AccountAdmin"] = user;
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Thông báo
                    ModelState.AddModelError("error", "Đăng nhập thất bại");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}