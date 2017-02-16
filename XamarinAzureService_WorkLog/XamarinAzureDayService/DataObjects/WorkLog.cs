using Microsoft.Azure.Mobile.Server;
using System;

namespace XamarinAzureDayService.DataObjects
{
    public class WorkLog : EntityData
    {
        public string 專案名稱 { get; set; }
        public DateTime 日期 { get; set; }
        public double 處理時間 { get; set; }
        public string 工作內容 { get; set; }
    }
}