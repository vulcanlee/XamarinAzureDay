using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XFWebAPI.Controllers
{
    public class SumDataController : ApiController
    {
        public int Get(int value1, int value2)
        {
            return value1+value2;
        }
    }
}
