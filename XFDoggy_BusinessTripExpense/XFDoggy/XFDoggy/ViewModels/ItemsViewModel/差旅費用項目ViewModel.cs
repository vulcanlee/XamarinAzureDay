using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class 差旅費用項目ViewModel : BindableBase
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

        #region 出差日期
        private DateTime _出差日期=DateTime.Now.AddDays(-1);
        /// <summary>
        /// 出差日期
        /// </summary>
        public DateTime 出差日期
        {
            get { return this._出差日期; }
            set { this.SetProperty(ref this._出差日期, value); }
        }
        #endregion

        #region 類型
        private string _類型;
        /// <summary>
        /// 類型
        /// </summary>
        public string 類型
        {
            get { return this._類型; }
            set { this.SetProperty(ref this._類型, value); }
        }
        #endregion

        #region 項目名稱
        private string _項目名稱;
        /// <summary>
        /// 項目名稱
        /// </summary>
        public string 項目名稱
        {
            get { return this._項目名稱; }
            set { this.SetProperty(ref this._項目名稱, value); }
        }
        #endregion

        #region 地點
        private string _地點;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string 地點
        {
            get { return this._地點; }
            set { this.SetProperty(ref this._地點, value); }
        }
        #endregion

        #region 費用
        private double _費用;
        /// <summary>
        /// 費用
        /// </summary>
        public double 費用
        {
            get { return this._費用; }
            set { this.SetProperty(ref this._費用, value); }
        }
        #endregion

        #region 備註
        private string _備註;
        /// <summary>
        /// 備註
        /// </summary>
        public string 備註
        {
            get { return this._備註; }
            set { this.SetProperty(ref this._備註, value); }
        }
        #endregion

        #region 國內外
        private bool _國內外;
        /// <summary>
        /// 國內外
        /// </summary>
        public bool 國內外
        {
            get { return this._國內外; }
            set { this.SetProperty(ref this._國內外, value); }
        }
        #endregion

        #region 是否有單據
        private bool _是否有單據;
        /// <summary>
        /// 是否有單據
        /// </summary>
        public bool 是否有單據
        {
            get { return this._是否有單據; }
            set { this.SetProperty(ref this._是否有單據, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        #endregion

        #region Constructor 建構式
        public 差旅費用項目ViewModel()
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
