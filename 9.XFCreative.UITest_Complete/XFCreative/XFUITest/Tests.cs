using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XFUITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

            // 解開底下這行註解，則會進入到 REPL  (read-eval-print-loop)
            //app.Repl();
        }

        [Test]
        public void AppLaunches()
        {
            AppResult[] result;
          
            #region 登入頁面
            result = app.WaitForElement((x => x.Marked("btnLoginCommand")));
            Assert.IsTrue(result.Any(), "無法進入到登入頁面");
            app.Screenshot("登入頁面");

            // 輸入錯誤的帳號與密碼
            app.EnterText(c => c.Marked("enyAccount"), "Vulcan");
            app.EnterText(c => c.Marked("enyPassword"), "Password123");
            app.Tap(c => c.Marked("btnLoginCommand"));
            result = app.WaitForElement((x => x.Marked("帳號與密碼輸入錯誤")));
            Assert.IsTrue(result.Any(), "無法看到對話窗 帳號與密碼輸入錯誤");
            app.Screenshot("帳號與密碼輸入錯誤");
            app.Tap(c => c.Marked("確定"));
            result = app.WaitForElement((x => x.Marked("btnLoginCommand")));
            Assert.IsTrue(result.Any(), "無法回到登入頁面");

            // 清除原先輸入的帳密
            app.ClearText(c => c.Marked("enyAccount"));
            app.ClearText(c => c.Marked("enyPassword"));

            // 輸入正確的帳密
            app.EnterText(c => c.Marked("enyAccount"), "1");
            app.EnterText(c => c.Marked("enyPassword"), "1");
            app.Tap(c => c.Marked("btnLoginCommand"));
            #endregion

            #region 搜尋高雄市的資料
            result = app.WaitForElement((x => x.Marked("創業空間清單")));
            Assert.IsTrue(result.Any(), "無法進入到應用程式首頁");
            app.Screenshot("首頁頁面");
            #endregion

            #region 搜尋高雄市的資料
            app.Tap("搜尋");
            result = app.WaitForElement((x => x.Marked("請選擇要篩選的縣市")));
            app.Screenshot("搜尋清單");
            app.Tap("高雄市");
            result = app.WaitForElement((x => x.Marked("高雄市")));
            Assert.IsTrue(result.Any(), "無法顯示縣市過濾清單");
            app.Screenshot("高雄市");
            #endregion

            #region 查看某筆資料明細
            app.Tap("大瀚放空間 Fun space");
            result = app.WaitForElement((x => x.Marked("所屬單位")));
            Assert.IsTrue(result.Any(), "無法顯示 大瀚高雄會議中心明細資料");
            app.Screenshot("資料明細頁面");
            app.Back();
            #endregion

            #region 捲動選取基隆市
            app.Tap("搜尋");
            app.WaitForElement((x => x.Marked("請選擇要篩選的縣市")));
            app.ScrollDownTo("嘉義縣", "臺北市", ScrollStrategy.Auto, 1, 1000, true, null);
            app.Tap("基隆市");
            app.WaitForElement((x => x.Marked("基隆市")));
            Assert.IsTrue(result.Any(), "無法顯示 過濾後的資料 for 基隆市");
            app.Screenshot("搜尋基隆市結果");
            #endregion

            #region 回到台北市
            app.Tap("搜尋");
            app.WaitForElement((x => x.Marked("請選擇要篩選的縣市")));
            app.Tap("臺北市");
            app.Screenshot("搜尋台北市結果");
            #endregion
        }
    }
}

