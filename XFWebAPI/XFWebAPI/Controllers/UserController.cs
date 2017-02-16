using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XFWebAPI.DAL;
using XFWebAPI.Models;

namespace XFWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private DoggyContext db = new DoggyContext();
        // GET: api/User
        public IEnumerable<User> Get()
        {
            return db.User.ToList();
        }


        [HttpPost]
        public AuthUserResult Auth(AuthUser authUser)
        {
            var fooItem = db.User.FirstOrDefault(x => x.Account == authUser.Account && x.Password == authUser.Password);
            if (fooItem != null)
            {
                return new AuthUserResult { Status = true };
            }
            else
            {
                return new AuthUserResult { Status = false };
            }
        }
    }
}
