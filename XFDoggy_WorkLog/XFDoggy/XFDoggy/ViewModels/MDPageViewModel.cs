using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using XFDoggy.Models;
using Prism.Events;
using XFDoggy.Helpers;

namespace XFDoggy.ViewModels
{
    public class MDPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 功能表項目與代表圖示的顏色
        #region 差旅費用申請Color
        private Color _差旅費用申請Color;
        /// <summary>
        /// 差旅費用申請Color
        /// </summary>
        public Color 差旅費用申請Color
        {
            get { return this._差旅費用申請Color; }
            set { this.SetProperty(ref this._差旅費用申請Color, value); }
        }
        #endregion

        #region 我要請假Color
        private Color _我要請假Color;
        /// <summary>
        /// 我要請假Color
        /// </summary>
        public Color 我要請假Color
        {
            get { return this._我要請假Color; }
            set { this.SetProperty(ref this._我要請假Color, value); }
        }
        #endregion

        #region 填寫工作日報表Color
        private Color _填寫工作日報表Color;
        /// <summary>
        /// 填寫工作日報表Color
        /// </summary>
        public Color 填寫工作日報表Color
        {
            get { return this._填寫工作日報表Color; }
            set { this.SetProperty(ref this._填寫工作日報表Color, value); }
        }
        #endregion

        #region 最新消息Color
        private Color _最新消息Color;
        /// <summary>
        /// 最新消息Color
        /// </summary>
        public Color 最新消息Color
        {
            get { return this._最新消息Color; }
            set { this.SetProperty(ref this._最新消息Color, value); }
        }
        #endregion

        #region 登出Color
        private Color _登出Color;
        /// <summary>
        /// 登出Color
        /// </summary>
        public Color 登出Color
        {
            get { return this._登出Color; }
            set { this.SetProperty(ref this._登出Color, value); }
        }
        #endregion

        #region OnCall電話Color
        private Color _OnCall電話;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public Color OnCall電話Color
        {
            get { return this._OnCall電話; }
            set { this.SetProperty(ref this._OnCall電話, value); }
        }
        #endregion

        #region 關於Color
        private Color _關於Color;
        /// <summary>
        /// 關於Color
        /// </summary>
        public Color 關於Color
        {
            get { return this._關於Color; }
            set { this.SetProperty(ref this._關於Color, value); }
        }
        #endregion


        #endregion

        #region 漢堡按鈕顯示
        private bool _漢堡按鈕顯示 = true;
        /// <summary>
        /// 漢堡按鈕顯示
        /// </summary>
        public bool 漢堡按鈕顯示
        {
            get { return this._漢堡按鈕顯示; }
            set { this.SetProperty(ref this._漢堡按鈕顯示, value); }
        }
        #endregion


        #endregion

        #region Field 欄位

        public DelegateCommand 差旅費用申請Command { get; set; }
        public DelegateCommand 我要請假Command { get; set; }
        public DelegateCommand 填寫工作日報表Command { get; set; }
        public DelegateCommand 最新消息Command { get; set; }
        public DelegateCommand 登出Command { get; set; }
        public DelegateCommand OnCall電話Command { get; set; }
        public DelegateCommand 關於Command { get; set; }

        private readonly IEventAggregator _eventAggregator;
        public readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;

        Color 尚未點選之功能表項目顏色 = Color.FromHex("#AA000000");
        Color 已經點選之功能表項目顏色 = Color.FromHex("#e88229");
        SubscriptionToken fooSubscriptionToken = null;
        #endregion

        #region Constructor 建構式
        public MDPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _navigationService = navigationService;

            #region Prism 事件聚合器
            fooSubscriptionToken = _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Subscribe(x =>
           {
               漢堡按鈕顯示 = x;
           });
            #endregion

            #region 點選功能表項目，要執行的命令
            差旅費用申請Command = new DelegateCommand(async () =>
            {
                if (fooSubscriptionToken != null)
                {
                    _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Unsubscribe(fooSubscriptionToken);
                }
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.差旅費用申請.ToString()}/NaviPage/差旅費用申請HomePage");
            });
            我要請假Command = new DelegateCommand(async () =>
            {
                if (fooSubscriptionToken != null)
                {
                    _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Unsubscribe(fooSubscriptionToken);
                }
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.我要請假.ToString()}/NaviPage/我要請假HomePage");
            });
            填寫工作日報表Command = new DelegateCommand(async () =>
            {
                if (fooSubscriptionToken != null)
                {
                    _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Unsubscribe(fooSubscriptionToken);
                }
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.填寫工作日報表.ToString()}/NaviPage/填寫工作日報表HomePage");
            });
            最新消息Command = new DelegateCommand(async () =>
            {
                if (fooSubscriptionToken != null)
                {
                    _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Unsubscribe(fooSubscriptionToken);
                }
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.最新消息.ToString()}/NaviPage/最新消息HomePage");
            });
            登出Command = new DelegateCommand(async () =>
            {
                if (fooSubscriptionToken != null)
                {
                    _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Unsubscribe(fooSubscriptionToken);
                }
                await _navigationService.NavigateAsync($"xf:///LoginPage");
            });

            OnCall電話Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.OnCall電話.ToString()}/NaviPage/OnCall電話Page");
            });
            關於Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.關於.ToString()}/NaviPage/MainPage");
            });

            #endregion
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Set功能表項目已經啟用();
            if (parameters.ContainsKey("Menu"))
            {
                // 若有傳入正在執行的功能表項目，則將這個功能表項目予以高亮
                var fooMenu = parameters["Menu"] as string;
                var fooMenuEnum = (MenuItemEnum)Enum.Parse(typeof(MenuItemEnum), fooMenu);
                Set功能表項目已經啟用(fooMenuEnum);
            }
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
        /// 依據所點選的功能表項目，將這個功能表項目文字與圖示，變換成為已選取的顏色
        /// </summary>
        /// <param name="pMenuItemEnum"></param>
        void Set功能表項目已經啟用(MenuItemEnum pMenuItemEnum = MenuItemEnum.全部重置)
        {
            差旅費用申請Color = 尚未點選之功能表項目顏色;
            我要請假Color = 尚未點選之功能表項目顏色;
            填寫工作日報表Color = 尚未點選之功能表項目顏色;
            最新消息Color = 尚未點選之功能表項目顏色;
            登出Color = 尚未點選之功能表項目顏色;

            switch (pMenuItemEnum)
            {
                case MenuItemEnum.全部重置:
                    break;
                case MenuItemEnum.差旅費用申請:
                    差旅費用申請Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.我要請假:
                    我要請假Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.填寫工作日報表:
                    填寫工作日報表Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.最新消息:
                    最新消息Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.登出:
                    登出Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.OnCall電話:
                    OnCall電話Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.關於:
                    關於Color = 已經點選之功能表項目顏色;
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
