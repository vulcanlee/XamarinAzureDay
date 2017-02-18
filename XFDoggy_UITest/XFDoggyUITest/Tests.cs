using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XFDoggyUITest
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
            app.Screenshot("First screen.");
        }

        [Test]
        public void NewTest()
        {
            app.Tap(x => x.Class("EntryEditText").Index(1));
            app.EnterText(x => x.Class("EntryEditText").Index(1), "1");
            app.Tap(x => x.Text("1"));
            app.Tap(x => x.Text("登入"));
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Text("差旅費用申請"));
            app.Tap(x => x.Class("FormsImageView").Index(2));
            app.EnterText(x => x.Class("EntryEditText").Index(3), "0");
            app.Tap(x => x.Class("EntryEditText"));
            app.EnterText(x => x.Class("EntryEditText"), "adsaf");
            app.Tap(x => x.Class("EntryEditText").Index(1));
            app.EnterText(x => x.Class("EntryEditText").Index(1), "asdfsad");
            app.Tap(x => x.Text("0"));
            app.EnterText(x => x.Class("EntryEditText").Text("0"), "023232");
            app.ScrollDownTo("儲存");
            app.Tap(x => x.Text("儲存"));
        }
    }
}

