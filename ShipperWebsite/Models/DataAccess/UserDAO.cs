using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipperWebsite.Models.ShipperAdmin;

namespace ShipperWebsite.Models.DataAccess
{
    public class UserDAO
    {
        private ShipperAdminDbContext db = new ShipperAdminDbContext();

        public UserAdmin Login(string userName, string password)
        {
            UserAdmin user = db.UserAdmin.SingleOrDefault(u => u.UserName == userName && u.Password_ == password);
            return user;
        }
    }
}