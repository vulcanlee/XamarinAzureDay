using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFHocKey
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new XFHocKey.MainPage();

            // 這裡使用 NavigationPage ，這是因為當登入帳密正確之後，需要切到 MainPage 頁面
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
