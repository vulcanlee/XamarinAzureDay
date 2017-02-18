using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class 工作日報表項目ViewModel : BindableBase
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region ID
        private string _ID;
        /// <summary>
        /// ID
        /// </summary>
        public string ID
        {
            get { return this._ID; }
            set { this.SetProperty(ref this._ID, value); }
        }
        #endregion

        #region 專案名稱
        private string _專案名稱;
        /// <summary>
        /// 專案名稱
        /// </summary>
        public string 專案名稱
        {
            get { return this._專案名稱; }
            set { this.SetProperty(ref this._專案名稱, value); }
        }
        #endregion

        #region 日期
        private DateTime _日期=DateTime.Now.Date;
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime 日期
        {
            get { return this._日期; }
            set { this.SetProperty(ref this._日期, value); }
        }
        #endregion

        #region 處理時間
        private double _處理時間;
        /// <summary>
        /// 處理時間
        /// </summary>
        public double 處理時間
        {
            get { return this._處理時間; }
            set { this.SetProperty(ref this._處理時間, value); }
        }
        #endregion

        #region 工作內容
        private string _工作內容;
        /// <summary>
        /// 工作內容
        /// </summary>
        public string 工作內容
        {
            get { return this._工作內容; }
            set { this.SetProperty(ref this._工作內容, value); }
        }
        #endregion

        #region 當日累計工時
        private double propertyName;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public double 當日累計工時
        {
            get { return this.propertyName; }
            set { this.SetProperty(ref this.propertyName, value); }
        }
        #endregion

        #region 是否顯示日期區塊
        private bool _是否顯示日期區塊 = false;
        /// <summary>
        /// 是否顯示日期區塊
        /// </summary>
        public bool 是否顯示日期區塊
        {
            get { return this._是否顯示日期區塊; }
            set { this.SetProperty(ref this._是否顯示日期區塊, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        #endregion

        #region Constructor 建構式
        public 工作日報表項目ViewModel()
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
