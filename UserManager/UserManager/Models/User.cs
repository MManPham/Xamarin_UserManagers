﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public  string Address { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }


        public User()
        {

        }

    }
}
