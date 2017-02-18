using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using XFDoggy.Helpers;

namespace XFDoggy.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IAuthenticate
    {
        #region Azure Mobile 身分驗證
        // Define a authenticated user.
        private MobileServiceUser user;
        public async Task<bool> Authenticate(MobileServiceAuthenticationProvider p登入方式)
        {
            var success = false;
            var message = string.Empty;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                if (user == null)
                {
                    // 每次登入的時候，都要強制重新登入，不使用上次登入的資訊
                    // https://developer.xamarin.com/guides/xamarin-forms/web-services/authentication/azure/
                    foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
                    {
                        NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
                    }
                    await MainHelper.client.LogoutAsync();
                    // 呼叫 Azure Mobile 用戶端的 LoginAsync 方法，依據指定的登入類型，進行身分驗證登入
                    user = await MainHelper.client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, p登入方式);
                    if (user != null)
                    {
                        message = string.Format("You are now signed-in as {0}.", user.UserId);
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            UIAlertView avAlert = new UIAlertView("Sign-in result", message, null, "OK", null);
            avAlert.Show();

            return success;
        }

        #endregion

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));

            // http://stackoverflow.com/questions/24521355/azure-mobile-services-invalid-operation-exception-platform-specific-assembly-n
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            #region Azure 行動應用之身分驗證用到程式碼
            // 將在 Android 原生平台實作的 IAuthenticate 物件，指定到 核心PCL 專案內
            App.Init((IAuthenticate)this);
            #endregion

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }

}
