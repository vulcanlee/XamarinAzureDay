using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.Models
{
    public class AuthUser
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
    public class AuthUserResult
    {
        public bool Status { get; set; }
    }
}
