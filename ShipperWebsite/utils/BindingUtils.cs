using ShipperWebsite.FirebaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipperWebsite.utils
{
    public class BindingUtils
    {
        public static List<User> UserBinding(Dictionary<String, User> data)
        {
            var model = data.Select(u => new User
            {
                UserID = u.Key,
                Email = u.Value.Email,
                FullName = u.Value.FullName,
                Phone = u.Value.Phone,
                ProfilePicture = u.Value.ProfilePicture
            }).ToList();
            return model;
        }
    }
}