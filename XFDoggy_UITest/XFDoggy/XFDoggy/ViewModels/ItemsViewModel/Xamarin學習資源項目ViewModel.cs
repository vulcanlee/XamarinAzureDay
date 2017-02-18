using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class Xamarin學習資源項目ViewModel : BindableBase
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 名稱
        private string _名稱;
        /// <summary>
        /// 名稱
        /// </summary>
        public string 名稱
        {
            get { return this._名稱; }
            set { this.SetProperty(ref this._名稱, value); }
        }
        #endregion

        #region URL
        private string _URL;
        /// <summary>
        /// URL
        /// </summary>
        public string URL
        {
            get { return this._URL; }
            set { this.SetProperty(ref this._URL, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        #endregion

        #region Constructor 建構式
        public Xamarin學習資源項目ViewModel()
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
