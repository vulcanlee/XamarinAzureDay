using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFChat.Models
{
    public enum 對話類型
    {
        他人,
        自己
    }
    public class ChatContent : BindableBase
    {
        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 對話人圖片
        private string _對話人圖片;
        /// <summary>
        /// 對話人圖片
        /// </summary>
        public string 對話人圖片
        {
            get { return this._對話人圖片; }
            set { this.SetProperty(ref this._對話人圖片, value); }
        }
        #endregion

        #region 對話內容
        private string _對話內容;
        /// <summary>
        /// 對話內容
        /// </summary>
        public string 對話內容
        {
            get { return this._對話內容; }
            set { this.SetProperty(ref this._對話內容, value); }
        }
        #endregion

        #region 對話類型
        private 對話類型 _對話類型;
        /// <summary>
        /// 對話類型
        /// </summary>
        public 對話類型 對話類型
        {
            get { return this._對話類型; }
            set { this.SetProperty(ref this._對話類型, value); }
        }
        #endregion

        #region 對話文字顏色
        private Color _對話文字顏色;
        /// <summary>
        /// 對話文字顏色
        /// </summary>
        public Color 對話文字顏色
        {
            get { return this._對話文字顏色; }
            set { this.SetProperty(ref this._對話文字顏色, value); }
        }
        #endregion

        #endregion

        #region Field 欄位

        #endregion

        #region Constructor 建構式
        public ChatContent()
        {

            #region 相依性服務注入的物件

            #endregion

            #region 頁面中綁定的命令

            #endregion

            #region 事件聚合器訂閱

            #endregion
        }

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
