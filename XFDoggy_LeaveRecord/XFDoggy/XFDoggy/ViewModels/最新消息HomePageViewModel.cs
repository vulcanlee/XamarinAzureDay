using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;
using XFDoggy.Repositories;
using XFDoggy.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Prism.Services;

namespace XFDoggy.ViewModels
{
    public class 最新消息HomePageViewModel : BindableBase, INavigationAware
    {

        #region Repositories (遠端或本地資料存取)
        最新消息Repository foo最新消息Repository = new 最新消息Repository();
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)
        #region 最新消息清單
        private ObservableCollection<最新消息項目ViewModel> _最新消息清單 = new ObservableCollection<最新消息項目ViewModel>();
        /// <summary>
        /// 最新消息清單
        /// </summary>
        public ObservableCollection<最新消息項目ViewModel> 最新消息清單
        {
            get { return _最新消息清單; }
            set { SetProperty(ref _最新消息清單, value); }
        }
        #endregion

        #region 顯示忙碌中遮罩
        private bool _顯示忙碌中遮罩;
        /// <summary>
        /// 顯示忙碌中遮罩
        /// </summary>
        public bool 顯示忙碌中遮罩
        {
            get { return this._顯示忙碌中遮罩; }
            set { this.SetProperty(ref this._顯示忙碌中遮罩, value); }
        }
        #endregion

        #region 正在進行清單資料更新
        private bool _正在進行清單資料更新 = false;
        /// <summary>
        /// 正在進行清單資料更新
        /// </summary>
        public bool 正在進行清單資料更新
        {
            get { return this._正在進行清單資料更新; }
            set { this.SetProperty(ref this._正在進行清單資料更新, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        public Action Check是否需要動態讀入資料Action = null;
        bool 啟用動態資料載入檢查 = false;

        // 使用 DelegateCommand<T> 可以接收來自於 XAML 中指定 CommandParameter 物件
        public DelegateCommand<最新消息項目ViewModel> 選取Command { get; set; }

        public DelegateCommand Refresh最新消息清單Command { get; set; }
        // 使用 DelegateCommand<T> 可以接收來自於行為所指定的事件參數
        public DelegateCommand<ItemVisibilityEventArgs> ItemAppearingCommand { get; set; }

        public readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region Constructor 建構式
        public 最新消息HomePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator,
            IPageDialogService dialogService)
        {
            #region 相依性服務注入的物件

            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            ItemAppearingCommand = new DelegateCommand<ItemVisibilityEventArgs>(async (x) =>
            {
                await Check是否需要動態讀入資料(x.Item);
            });

            Refresh最新消息清單Command = new DelegateCommand(async () =>
            {
                正在進行清單資料更新 = true;
                最新消息清單.Clear();
                await foo最新消息Repository.Read();
                啟用動態資料載入檢查 = false;
                foreach (var item in foo最新消息Repository.最新消息)
                {
                    最新消息清單.Add(new 最新消息項目ViewModel
                    {
                        ID = item.ID,
                        名稱 = item.名稱,
                    });
                }
                啟用動態資料載入檢查 = true;
                正在進行清單資料更新 = false;
            });
            選取Command = new DelegateCommand<最新消息項目ViewModel>(async x =>
            {
                await _dialogService.DisplayAlertAsync("資訊", $"您選取的是 {x.名稱}", "確定");
            });
            #endregion
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Init();
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
        private async Task Init()
        {
            顯示忙碌中遮罩 = true;
            最新消息清單.Clear();
            await foo最新消息Repository.Read();
            啟用動態資料載入檢查 = false;
            foreach (var item in foo最新消息Repository.最新消息)
            {
                最新消息清單.Add(new 最新消息項目ViewModel
                {
                    ID = item.ID,
                    名稱 = item.名稱,
                });
            }
            啟用動態資料載入檢查 = true;
            顯示忙碌中遮罩 = false;
        }

        private async Task Check是否需要動態讀入資料(object item)
        {
            if (啟用動態資料載入檢查 == false)
            {
                顯示忙碌中遮罩 = false;
                return;
            }
            var fooObj = foo最新消息Repository.最新消息.LastOrDefault();
            if (fooObj == null)
            {
                顯示忙碌中遮罩 = false;
                return;
            }
            var fooItem = item as 最新消息項目ViewModel;
            if (fooItem.ID == fooObj.ID)
            {
                顯示忙碌中遮罩 = true;
                await foo最新消息Repository.Read(最新消息清單.Count);
                foreach (var foo最新消息Item in foo最新消息Repository.最新消息)
                {
                    最新消息清單.Add(new 最新消息項目ViewModel
                    {
                        ID = foo最新消息Item.ID,
                        名稱 = foo最新消息Item.名稱,
                    });
                }
                顯示忙碌中遮罩 = false;
            }
        }

        #endregion
    }
}
