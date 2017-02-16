using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.Models
{
    public class WorkLog
    {
        public string Id { get; set; }
        public string 專案名稱 { get; set; }
        public DateTime 日期 { get; set; }
        public double 處理時間 { get; set; }
        public string 工作內容 { get; set; }
    }
}
