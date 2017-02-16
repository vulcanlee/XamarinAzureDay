using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using XFDoggy.Helpers;

using Gcm.Client;
using XFDoggy.Droid.Infrastructure;

[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.CallPhone)]
namespace XFDoggy.Droid
{
    [Activity(Label = "多奇數位創意", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        #region Firebase 的推播設定用程式碼
        // Create a new instance field for this activity.
        static MainActivity instance = null;

        // Return the current activity instance.
        public static MainActivity CurrentActivity
        {
            get
            {
                return instance;
            }
        }

        #endregion

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

            #region Firebase 的推播設定用程式碼
            // Set the current instance of MainActivity.
            instance = this;
            #endregion

            LoadApplication(new App(new AndroidInitializer()));

            #region Firebase 的推播設定用程式碼
            try
            {
                // Check to ensure everything's set up right
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);

                // Register for push notifications
                System.Diagnostics.Debug.WriteLine("Registering...");
                GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
            }
            catch (Java.Net.MalformedURLException)
            {
                CreateAndShowDialog("There was an error creating the client. Verify the URL.", "Error");
            }
            catch (Exception e)
            {
                CreateAndShowDialog(e.Message, "Error");
            }
            #endregion
        }

        #region Firebase 的推播設定用程式碼
        private void CreateAndShowDialog(String message, String title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
        #endregion

        #region Firebase 的推播設定用程式碼

        #endregion
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

