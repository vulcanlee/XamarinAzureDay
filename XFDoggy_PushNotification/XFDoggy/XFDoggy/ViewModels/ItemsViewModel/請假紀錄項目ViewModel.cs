using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class 請假紀錄項目ViewModel : BindableBase
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region ID
        private string _ID = Guid.NewGuid().ToString();
        /// <summary>
        /// ID
        /// </summary>
        public string ID
        {
            get { return this._ID; }
            set { this.SetProperty(ref this._ID, value); }
        }
        #endregion

        #region 申請人
        private string _申請人;
        /// <summary>
        /// 申請人
        /// </summary>
        public string 申請人
        {
            get { return this._申請人; }
            set { this.SetProperty(ref this._申請人, value); }
        }
        #endregion

        #region 請假日期
        private DateTime _請假日期 = DateTime.Now.AddDays(2);
        /// <summary>
        /// 請假日期
        /// </summary>
        public DateTime 請假日期
        {
            get { return this._請假日期; }
            set { this.SetProperty(ref this._請假日期, value); }
        }
        #endregion

        #region 開始時間
        private TimeSpan _開始時間 = new TimeSpan(9, 0, 0);
        /// <summary>
        /// 開始時間
        /// </summary>
        public TimeSpan 開始時間
        {
            get { return this._開始時間; }
            set { this.SetProperty(ref this._開始時間, value); }
        }
        #endregion

        #region 請假時數
        private int _請假時數 = 8;
        /// <summary>
        /// 請假時數
        /// </summary>
        public int 請假時數
        {
            get { return this._請假時數; }
            set { this.SetProperty(ref this._請假時數, value); }
        }
        #endregion

        #region 假別
        private string _假別 = "請選擇";
        /// <summary>
        /// 假別
        /// </summary>
        public string 假別
        {
            get { return this._假別; }
            set { this.SetProperty(ref this._假別, value); }
        }
        #endregion

        #region 請假理由
        private string _請假理由;
        /// <summary>
        /// 請假理由
        /// </summary>
        public string 請假理由
        {
            get { return this._請假理由; }
            set { this.SetProperty(ref this._請假理由, value); }
        }
        #endregion

        #region 職務代理人
        private string _職務代理人;
        /// <summary>
        /// 職務代理人
        /// </summary>
        public string 職務代理人
        {
            get { return this._職務代理人; }
            set { this.SetProperty(ref this._職務代理人, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        #endregion

        #region Constructor 建構式
        public 請假紀錄項目ViewModel()
        {

        }
        #endregion

        #region Navigation Events (頁面導航事件)
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

    }
}
