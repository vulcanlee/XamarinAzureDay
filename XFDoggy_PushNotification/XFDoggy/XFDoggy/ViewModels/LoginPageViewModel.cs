using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using XFDoggy.Models;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)
        #endregion

        #region Field 欄位

        public DelegateCommand 登入Command { get; set; }
        public DelegateCommand Facebook登入Command { get; set; }
        public DelegateCommand Google登入Command { get; set; }

        public readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor 建構式
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {

            _dialogService = dialogService;
            _navigationService = navigationService;

            登入Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.關於.ToString()}/NaviPage/MainPage?title=多奇數位創意有限公司");
            });
            Facebook登入Command = new DelegateCommand(async () =>
            {
                var fooResult = await App.Authenticator.Authenticate(Microsoft.WindowsAzure.MobileServices.MobileServiceAuthenticationProvider.Facebook);
                if (fooResult == true)
                {
                    // 這裡需要暫停一段時間，根據 Xamarin JamesMontemagno 的說法
                    //The issue most likely is just caused that you are attempting to transition too fast before the page is actually re-inflated. 
                    //This usually can be caused by open a new activity such as the scanner page or login page. I would play around with the
                    // await Task.Delay(300);
                    //with different timings there and put a spinner perhaps.
                    await Task.Delay(300);
                    await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.關於.ToString()}/NaviPage/MainPage?title=多奇數位創意有限公司");
                }
            });
            Google登入Command = new DelegateCommand(async () =>
            {
                var fooResult = await App.Authenticator.Authenticate(Microsoft.WindowsAzure.MobileServices.MobileServiceAuthenticationProvider.Google);
                if (fooResult == true)
                {
                    await Task.Delay(300);
                    await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.關於.ToString()}/NaviPage/MainPage?title=多奇數位創意有限公司");
                }
            });
        }
        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法
        #endregion

    }
}
