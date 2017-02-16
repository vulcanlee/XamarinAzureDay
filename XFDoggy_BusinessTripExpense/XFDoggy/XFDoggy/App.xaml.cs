using Prism.Unity;
using XFDoggy.Models;
using XFDoggy.Views;

namespace XFDoggy
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.關於.ToString()}/NaviPage/MainPage?title=多奇數位創意有限公司");
            NavigationService.NavigateAsync($"LoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MDPage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<OnCall電話Page>();
            Container.RegisterTypeForNavigation<我要請假HomePage>();
            Container.RegisterTypeForNavigation<我要請假記錄修改Page>();
            Container.RegisterTypeForNavigation<差旅費用申請HomePage>();
            Container.RegisterTypeForNavigation<差旅費用申請紀錄修改Page>();
            Container.RegisterTypeForNavigation<最新消息HomePage>();
            Container.RegisterTypeForNavigation<填寫工作日報表HomePage>();
            Container.RegisterTypeForNavigation<填寫工作日報表記錄修改Page>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
