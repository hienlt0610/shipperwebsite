using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipperWebsite.FirebaseModel
{
    public class User
    {
        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        private String userID;

        public String UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private String fullName;

        public String FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private String phone;

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private String profilePicture;

        public String ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; }
        }

    }
}