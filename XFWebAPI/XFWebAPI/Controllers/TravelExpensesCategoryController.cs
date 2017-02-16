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
    public class TravelExpensesCategoryController : ApiController
    {
        private DoggyContext db = new DoggyContext();
        // GET: api/TravelExpensesCategory
        public IEnumerable<TravelExpensesCategory> Get()
        {
            return db.TravelExpensesCategory.ToList();
        }
    }
}
