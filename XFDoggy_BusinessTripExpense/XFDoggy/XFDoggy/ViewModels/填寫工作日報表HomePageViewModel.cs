using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;
using XFDoggy.Repositories;
using System.Collections.ObjectModel;
using XFDoggy.Models;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class 填寫工作日報表HomePageViewModel : BindableBase, INavigationAware
    {

        #region Repositories (遠端或本地資料存取)
        工作日報表Repository foo工作日報表Repository = new 工作日報表Repository();
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)
        #region 工作日報表項目清單
        private ObservableCollection<工作日報表項目ViewModel> _工作日報表項目清單 = new ObservableCollection<工作日報表項目ViewModel>();
        /// <summary>
        /// 工作日報表項目清單
        /// </summary>
        public ObservableCollection<工作日報表項目ViewModel> 工作日報表項目清單
        {
            get { return _工作日報表項目清單; }
            set { SetProperty(ref _工作日報表項目清單, value); }
        }
        #endregion

        #region 點選工作日報表項目
        private 工作日報表項目ViewModel _點選工作日報表項目;
        /// <summary>
        /// 點選工作日報表項目
        /// </summary>
        public 工作日報表項目ViewModel 點選工作日報表項目
        {
            get { return this._點選工作日報表項目; }
            set { this.SetProperty(ref this._點選工作日報表項目, value); }
        }
        #endregion

        #endregion

        #region Field 欄位

        public DelegateCommand 點選工作日報表項目Command { get; set; }
        public DelegateCommand 點選新增工作日報表項目Command { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region Constructor 建構式
        public 填寫工作日報表HomePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            #region 相依性服務注入的物件

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            點選工作日報表項目Command = new DelegateCommand(async () =>
            {
                var fooID = 點選工作日報表項目.ID;
                點選工作日報表項目 = null;
                await _navigationService.NavigateAsync($"填寫工作日報表記錄修改Page?ID={fooID}");
            });
            點選新增工作日報表項目Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync($"填寫工作日報表記錄修改Page");
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
            工作日報表項目ViewModel fooHeader工作日報表項目 = null;
            工作日報表項目清單.Clear();
            await foo工作日報表Repository.Read();
            var foo工作日報表Items = foo工作日報表Repository.工作日報表.OrderBy(x => x.日期);
            foreach (var item in foo工作日報表Items)
            {
                var foo工作日報表項目 = new 工作日報表項目ViewModel
                {
                    ID = item.ID,
                    專案名稱 = item.專案名稱,
                    日期 = item.日期,
                    處理時間 = item.處理時間,
                    工作內容 = item.工作內容,
                    當日累計工時 = 0,
                    是否顯示日期區塊 = false,
                };
                if (fooHeader工作日報表項目 == null)
                {
                    fooHeader工作日報表項目 = foo工作日報表項目;
                    fooHeader工作日報表項目.當日累計工時 = foo工作日報表項目.處理時間;
                    fooHeader工作日報表項目.是否顯示日期區塊 = true;
                }
                else if (fooHeader工作日報表項目.日期.Date == foo工作日報表項目.日期.Date)
                {
                    fooHeader工作日報表項目.當日累計工時 += foo工作日報表項目.處理時間;
                }
                else
                {
                    fooHeader工作日報表項目 = foo工作日報表項目;
                    fooHeader工作日報表項目.當日累計工時 = foo工作日報表項目.處理時間;
                    fooHeader工作日報表項目.是否顯示日期區塊 = true;
                }
                工作日報表項目清單.Add(foo工作日報表項目);
            }
        }
        #endregion
    }
}
