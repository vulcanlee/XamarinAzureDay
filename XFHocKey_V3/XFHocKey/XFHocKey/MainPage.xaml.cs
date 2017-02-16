using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFHocKey
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Onbutton我崩潰了Clicked(object sender, EventArgs e)
        {
            // 自己發出一個例外異常，HocKeyApp 將會捕捉到這個例外異常的相關資訊
            throw new Exception("使用者自己選擇要崩潰了");
        }

        public void Onbutton我有話要說Clicked(object sender, EventArgs e)
        {
            // 透過訊息中心發出一個請求，可以使用 HocKeyApp 的 FeedbackManager 回報頁面
            MessagingCenter.Send<我要回報>(new 我要回報(), "是的，請說");
        }
    }
}
