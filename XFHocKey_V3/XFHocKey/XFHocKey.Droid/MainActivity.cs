using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;
using Xamarin.Forms;

namespace XFHocKey.Droid
{
    [Activity(Label = "多奇集團 行動儀表板", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public string HocKeyApp_ID = "ee4d14e6b55d41569395c176e9720ebb";
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            // 註冊程式異常崩壞的回報機制
            CrashManager.Register(this, HocKeyApp_ID);

            // 檢查是否有新版本推出，讓使用者可以選擇是否要升級
            CheckForUpdates();

            // 訊息中心訂閱者，當使用者在核心PCL內按下按鈕之後，訊息中心將會收到這個訊息通知，並且進行處理
            MessagingCenter.Subscribe<我要回報>(this, "是的，請說", (sender) =>
            {
                #region 讓使用者填寫意見，並記錄到 HocKeyApp
                FeedbackManager.Register(this, HocKeyApp_ID);
                FeedbackManager.ShowFeedbackActivity(ApplicationContext);
                #endregion
            });
        }

        void CheckForUpdates()
        {
            // Remove this for store builds!
            UpdateManager.Register(this, HocKeyApp_ID);
        }

        void UnregisterManagers()
        {
            UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterManagers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterManagers();
        }
    }
}

