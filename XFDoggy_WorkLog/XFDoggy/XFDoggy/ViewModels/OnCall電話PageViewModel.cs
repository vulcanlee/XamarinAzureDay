using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Collections.ObjectModel;
using XFDoggy.Models;
using Prism.Services;
using Plugin.Messaging;

namespace XFDoggy.ViewModels
{
    public class OnCall電話PageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)
        #region 部門緊急連絡方式清單
        private ObservableCollection<部門緊急連絡方式ViewModel> _部門緊急連絡方式清單 = new ObservableCollection<部門緊急連絡方式ViewModel>();
        /// <summary>
        /// 部門緊急連絡方式清單
        /// </summary>
        public ObservableCollection<部門緊急連絡方式ViewModel> 部門緊急連絡方式清單
        {
            get { return _部門緊急連絡方式清單; }
            set { SetProperty(ref _部門緊急連絡方式清單, value); }
        }
        #endregion

        #region 點選部門緊急連絡方式
        private 部門緊急連絡方式ViewModel _點選部門緊急連絡方式;
        /// <summary>
        /// 點選部門緊急連絡方式
        /// </summary>
        public 部門緊急連絡方式ViewModel 點選部門緊急連絡方式
        {
            get { return this._點選部門緊急連絡方式; }
            set { this.SetProperty(ref this._點選部門緊急連絡方式, value); }
        }
        #endregion

        #endregion

        #region Field 欄位

        public DelegateCommand 點選部門緊急連絡方式Command { get; set; }
        // 使用 DelegateCommand<T> 可以接收來自於 XAML 中指定 CommandParameter 物件
        public DelegateCommand<string> 點選電話號碼Command { get; set; }

        public readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor 建構式
        public OnCall電話PageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            #region 相依性服務注入的物件
            _dialogService = dialogService;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            點選部門緊急連絡方式Command = new DelegateCommand(async () =>
            {
                await _dialogService.DisplayAlertAsync("", "Test", "OK");
            });
            點選電話號碼Command = new DelegateCommand<string>(async x =>
            {
                var fooX = await _dialogService.DisplayAlertAsync("撥打電話", $"{x}", "確定", "取消");
                if (fooX == true)
                {
                    if (CrossMessaging.Current.PhoneDialer.CanMakePhoneCall == true)
                    {
                        CrossMessaging.Current.PhoneDialer.MakePhoneCall(x);
                    }
                }
            });
            #endregion
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Init();
        }

        #endregion

        #region Navigation Events (頁面導航事件)
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法
        /// <summary>
        /// 進行要顯示資料的初始化
        /// </summary>
        private void Init()
        {
            部門緊急連絡方式清單.Clear();
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "7X24 Help Desk",
                市話 = "02-2322-2480p6677",
                手機 = "0978654321"
            });
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "網路組",
                市話 = "02-2322-2480p5219",
                手機 = "0912345678"
            });
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "資料庫組",
                市話 = "02-2322-2480p2342",
                手機 = "0901111111"
            });
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "系統組",
                市話 = "02-2322-2480p1133",
                手機 = "0902222222"
            });
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "ERP組",
                市話 = "02-2322-2480p9644",
                手機 = "090333333"
            });
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "CRM組",
                市話 = "02-2322-2480p5332",
                手機 = "0905555555"
            });
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "SCM組",
                市話 = "02-2322-2480p9957",
                手機 = "0906666666"
            });
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "工務組",
                市話 = "02-2322-2480p6734",
                手機 = "09077777777"
            });
            部門緊急連絡方式清單.Add(new 部門緊急連絡方式ViewModel
            {
                部門 = "警衛室",
                市話 = "02-2322-2480p4633",
                手機 = "09088888888"
            });
        }
        #endregion

    }
}
