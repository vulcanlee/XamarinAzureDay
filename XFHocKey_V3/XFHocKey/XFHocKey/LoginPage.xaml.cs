using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFHocKey
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void Onbutton登入Clicked(object sender, EventArgs e)
        {
            if((entry帳號.Text??"") == "" && (entry密碼.Text??"") == "")
            {
                #region 帳號與密碼正確，切換到應用程式首頁
                label錯誤提示.IsVisible = false;
                label錯誤提示.Text = "";

                var NextPage = new MainPage();
                await Navigation.PushAsync(NextPage);

                清除導航頁面堆疊項目();
                #endregion
            }
            else
            {
                #region 帳號與密碼不正確，顯示一個錯誤提示訊息
                label錯誤提示.IsVisible = true;
                label錯誤提示.Text = "帳號與密碼錯誤";
                #endregion
            }
        }

        /// <summary>
        /// 此時，將無法使用硬體回上一頁按鍵，回到這個頁面
        /// </summary>
        private void 清除導航頁面堆疊項目()
        {
            var 頁面堆疊 = Navigation.NavigationStack;

            while (頁面堆疊.Count > 1)
            {
                var page = 頁面堆疊.First();
                if (page != null)
                {
                    Navigation.RemovePage(page);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
