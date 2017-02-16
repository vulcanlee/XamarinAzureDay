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
    public class TravelExpenseController : ApiController
    {
        private DoggyContext db = new DoggyContext();
        // GET: api/TravelExpense
        public IEnumerable<TravelExpense> Get(string account)
        {
            return db.TravelExpense.Where(x=>x.Account == account).ToList();
        }

        // GET: api/TravelExpense/5
        public TravelExpense Get(int id)
        {
            var fooItem = db.TravelExpense.FirstOrDefault(x => x.ID == id);
            return fooItem;
        }

        // POST: api/TravelExpense
        public void Post([FromBody]TravelExpense value)
        {
            db.TravelExpense.Add(value);
            db.SaveChanges();
        }

        // PUT: api/TravelExpense/5
        public void Put([FromBody]TravelExpense value)
        {
            var fooItem = db.TravelExpense.FirstOrDefault(x => x.ID == value.ID);
            if (fooItem != null)
            {
                fooItem.Account = value.Account;
                fooItem.Category = value.Category;
                fooItem.Domestic = value.Domestic;
                fooItem.Expense = value.Expense;
                fooItem.HasDocument = value.HasDocument;
                fooItem.Location = value.Location;
                fooItem.Memo = value.Memo;
                fooItem.Title = value.Title;
                fooItem.TravelDate = value.TravelDate;
                fooItem.Updatetime = value.Updatetime;
                db.SaveChanges();
            }
        }

        // DELETE: api/TravelExpense/5
        public void Delete(int id)
        {
            var fooItem = db.TravelExpense.FirstOrDefault(x => x.ID == id);
            if (fooItem != null)
            {
                db.TravelExpense.Remove(fooItem);
                db.SaveChanges();
            }
        }
    }
}
