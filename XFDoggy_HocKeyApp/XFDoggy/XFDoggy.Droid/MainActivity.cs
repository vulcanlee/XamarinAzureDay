using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using XFDoggy.Helpers;
using Android.Webkit;
using HockeyApp.Android;

[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.CallPhone)]
namespace XFDoggy.Droid
{
    [Activity(Label = "多奇數位創意", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        #region Azure 行動應用之身分驗證用到程式碼

        // Define a authenticated user.
        private MobileServiceUser user;


        public async Task<bool> Authenticate(MobileServiceAuthenticationProvider p登入方式)
        {
            // 驗證結果
            var success = false;
            // 要顯示的訊息
            var message = string.Empty;
            try
            {
                // 每次登入的時候，都要強制重新登入，不使用上次登入的資訊
                // https://developer.xamarin.com/guides/xamarin-forms/web-services/authentication/azure/
                CookieManager.Instance.RemoveAllCookie();
                await MainHelper.client.LogoutAsync();
                // 呼叫 Azure Mobile 用戶端的 LoginAsync 方法，依據指定的登入類型，進行身分驗證登入
                user = await MainHelper.client.LoginAsync(this, p登入方式);
                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.", user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // 顯示登入成功或者失敗.
            //AlertDialog.Builder builder = new AlertDialog.Builder(this);
            //builder.SetMessage(message);
            //builder.SetTitle("Sign-in result");
            //builder.Create().Show();

            return success;
        }
        #endregion

        #region HocKeyApp
        public string HocKeyApp_ID = "9f5e8019b4d74d0699735857889c2d1b";
        #endregion
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            #region Azure 行動應用之身分驗證用到程式碼
            // 將在 Android 原生平台實作的 IAuthenticate 物件，指定到 核心PCL 專案內
            App.Init((IAuthenticate)this);
            #endregion

            LoadApplication(new App(new AndroidInitializer()));

            #region HocKeyApp
            // 註冊程式異常崩壞的回報機制
            CrashManager.Register(this, HocKeyApp_ID);

            // 檢查是否有新版本推出，讓使用者可以選擇是否要升級
            CheckForUpdates();
            #endregion

        }

        #region HocKeyApp
        void CheckForUpdates()
        {
            // Remove this for store builds!
            UpdateManager.Register(this, HocKeyApp_ID);
        }

        void UnregisterManagers()
        {
            UpdateManager.Unregister();
        }
        #endregion
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

