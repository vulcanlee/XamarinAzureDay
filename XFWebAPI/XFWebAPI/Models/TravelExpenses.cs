using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XFWebAPI.Models
{
    public class TravelExpense
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public DateTime TravelDate { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public double Expense { get; set; }
        public string Memo { get; set; }
        public bool Domestic { get; set; }
        public bool HasDocument { get; set; }
        public DateTime Updatetime { get; set; }
    }

}