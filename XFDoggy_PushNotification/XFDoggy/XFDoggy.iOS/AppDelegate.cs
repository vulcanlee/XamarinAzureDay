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
using Newtonsoft.Json.Linq;

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
            #region 解決 Google OAuth2 的問題 Google Auth Error:disallowed_useragent
            // 參考文件：https://forums.xamarin.com/discussion/comment/247556#Comment_247556
            // define useragent android like
            string userAgent = "Mozilla/5.0 (Linux; Android 5.1.1; Nexus 5 Build/LMY48B; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/43.0.2357.65 Mobile Safari/537.36";

            // set default useragent
            NSDictionary dictionary = NSDictionary.FromObjectAndKey(NSObject.FromObject(userAgent), NSObject.FromObject("UserAgent"));
            NSUserDefaults.StandardUserDefaults.RegisterDefaults(dictionary);
            #endregion

            #region Azure 行動應用推播中樞修正
            // Register for push notifications.
            var settings = UIUserNotificationSettings.GetSettingsForTypes(
                UIUserNotificationType.Alert
                | UIUserNotificationType.Badge
                | UIUserNotificationType.Sound,
                new NSSet());

            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            UIApplication.SharedApplication.RegisterForRemoteNotifications();
            #endregion

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

        #region Azure 行動應用推播中樞修正
        public override void RegisteredForRemoteNotifications(UIApplication application,
         NSData deviceToken)
        {
            const string templateBodyAPNS = "{\"aps\":{\"alert\":\"$(messageParam)\"}}";

            JObject templates = new JObject();
            templates["genericMessage"] = new JObject
         {
           {"body", templateBodyAPNS}
         };

            // Register for push with your mobile app
            Push push = MainHelper.client.GetPush();
            push.RegisterAsync(deviceToken, templates);
        }

        public override void DidReceiveRemoteNotification(UIApplication application,
     NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            NSDictionary aps = userInfo.ObjectForKey(new NSString("aps")) as NSDictionary;

            string alert = string.Empty;
            if (aps.ContainsKey(new NSString("alert")))
                alert = (aps[new NSString("alert")] as NSString).ToString();

            //show alert
            if (!string.IsNullOrEmpty(alert))
            {
                UIAlertView avAlert = new UIAlertView("Notification", alert, null, "OK", null);
                avAlert.Show();
            }
        }
        #endregion
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }

}
