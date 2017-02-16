using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XFWebAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}