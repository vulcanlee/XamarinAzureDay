using Microsoft.WindowsAzure.MobileServices;
using Prism.Unity;
using System.Threading.Tasks;
using XFDoggy.Helpers;
using XFDoggy.Models;
using XFDoggy.Views;

namespace XFDoggy
{
    #region Azure Mobile 身分驗證介面
    /// <summary>
    /// 要透過 Azure 行動應用服務進行身分驗證的介面
    /// 實際實作的部分，會在每個原生專案中實作與
    /// </summary>
    public interface IAuthenticate
    {
        Task<bool> Authenticate(MobileServiceAuthenticationProvider p登入方式);
    }
    #endregion

    public partial class App : PrismApplication
    {
        #region Azure Mobile 身分驗證介面初始化
        /// <summary>
        /// 該介面所實際物件，會在原生專案中，指定實際實作物件
        /// </summary>
        public static IAuthenticate Authenticator { get; private set; }

        /// <summary>
        /// Azure 行動應用服務進行身分驗證的介面初始化方法
        /// </summary>
        /// <param name="authenticator"></param>
        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }
        #endregion

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.關於.ToString()}/NaviPage/MainPage?title=多奇數位創意有限公司");

            #region 進行離線資料庫初始化
            MainHelper.AzureMobileOfflineInit();
            #endregion

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
