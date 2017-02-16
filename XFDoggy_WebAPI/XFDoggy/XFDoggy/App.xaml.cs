using Prism.Unity;
using XFDoggy.Views;

namespace XFDoggy
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("LoadingPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<LoadingPage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<TravelExpensesListPage>();
            Container.RegisterTypeForNavigation<TravelExpensesPage>();
            Container.RegisterTypeForNavigation<MainMDPage>();
        }
    }
}
