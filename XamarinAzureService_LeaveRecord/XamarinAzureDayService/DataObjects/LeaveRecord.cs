using Microsoft.Azure.Mobile.Server;
using System;

namespace XamarinAzureDayService.DataObjects
{
    public class LeaveRecord : EntityData
    {
        public string 申請人 { get; set; }
        public DateTime 請假日期 { get; set; }
        public TimeSpan 開始時間 { get; set; }
        public int 請假時數 { get; set; }
        public string 假別 { get; set; }
        public string 請假理由 { get; set; }
        public string 職務代理人 { get; set; }
    }
}