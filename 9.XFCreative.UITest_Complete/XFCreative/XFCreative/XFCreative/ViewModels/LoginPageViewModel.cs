using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCreative.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        public readonly IPageDialogService _dialogService;
        public DelegateCommand LoginCommand { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _Account;
        public string Account
        {
            get { return _Account; }
            set { SetProperty(ref _Account, value); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            // 取得頁面導航的實作
            _navigationService = navigationService;
            _dialogService = dialogService;

            LoginCommand = new DelegateCommand(Login);
        }

        private async void Login()
        {
            if (Account != "1" && Password != "1")
                await _dialogService.DisplayAlert("抱歉", $"帳號與密碼輸入錯誤", "確定");
            else
                await _navigationService.Navigate("/MainPage?title=請稍後，正在更新資料");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " ...";

            await 系統初始化();
        }

        public async Task 系統初始化()
        {
        }

    }
}
