using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Models
{
    public class LoginAccept
    {
        public string  admin_name { get; set; }
        public string admin_password { get; set; }


        public LoginAccept(string  _name, string _password)
        {
            this.admin_name = _name;
            this.admin_password = _password;
        }

        public bool isAccept()
        {
            if (this.admin_name == "admink" && this.admin_password == "k123456")
            {
                return true;
            }
            else return false;
        }

    }
}
