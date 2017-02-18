using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class 部門緊急連絡方式ViewModel : BindableBase
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 部門
        private string _部門;
        /// <summary>
        /// 部門
        /// </summary>
        public string 部門
        {
            get { return this._部門; }
            set { this.SetProperty(ref this._部門, value); }
        }
        #endregion

        #region 市話
        private string _市話;
        /// <summary>
        /// 市話
        /// </summary>
        public string 市話
        {
            get { return this._市話; }
            set { this.SetProperty(ref this._市話, value); }
        }
        #endregion

        #region 手機
        private string _手機;
        /// <summary>
        /// 手機
        /// </summary>
        public string 手機
        {
            get { return this._手機; }
            set { this.SetProperty(ref this._手機, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        #endregion

        #region Constructor 建構式
        public 部門緊急連絡方式ViewModel()
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
        #endregion

    }
}
