using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.Models
{
    public class BusinessTripExpense
    {
        public string Id { get; set; }
        public DateTime 出差日期 { get; set; }
        public string 類型 { get; set; }
        public string 項目名稱 { get; set; }
        public string 地點 { get; set; }
        public double 費用 { get; set; }
        public string 備註 { get; set; }
        public bool 國內外 { get; set; }
        public bool 是否有單據 { get; set; }
    }
}
