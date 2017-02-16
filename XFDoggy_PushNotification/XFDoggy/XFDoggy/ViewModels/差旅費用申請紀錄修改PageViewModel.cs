using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;
using XFDoggy.Models;
using Xamarin.Forms;
using Prism.Services;

namespace XFDoggy.ViewModels
{
    public class 差旅費用申請紀錄修改PageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 差旅費用項目紀錄
        private 差旅費用項目ViewModel _差旅費用項目紀錄;
        /// <summary>
        /// 工作日報表項目紀錄
        /// </summary>
        public 差旅費用項目ViewModel 差旅費用項目紀錄
        {
            get { return this._差旅費用項目紀錄; }
            set { this.SetProperty(ref this._差旅費用項目紀錄, value); }
        }
        #endregion

        #region Title
        private string _Title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return this._Title; }
            set { this.SetProperty(ref this._Title, value); }
        }
        #endregion

        #region 儲存按鈕的ColumnSpan
        private int _儲存按鈕的ColumnSpan = 1;
        /// <summary>
        /// 儲存按鈕的ColumnSpan
        /// </summary>
        public int 儲存按鈕的ColumnSpan
        {
            get { return this._儲存按鈕的ColumnSpan; }
            set { this.SetProperty(ref this._儲存按鈕的ColumnSpan, value); }
        }
        #endregion

        #region 儲存按鈕的ColumnID
        private int _儲存按鈕的ColumnID = 1;
        /// <summary>
        /// 儲存按鈕的ColumnID
        /// </summary>
        public int 儲存按鈕的ColumnID
        {
            get { return this._儲存按鈕的ColumnID; }
            set { this.SetProperty(ref this._儲存按鈕的ColumnID, value); }
        }
        #endregion

        #region 儲存按鈕Margin
        private Thickness _儲存按鈕Margin;
        /// <summary>
        /// 儲存按鈕Margin
        /// </summary>
        public Thickness 儲存按鈕Margin
        {
            get { return this._儲存按鈕Margin; }
            set { this.SetProperty(ref this._儲存按鈕Margin, value); }
        }
        #endregion

        #endregion

        #region Field 欄位

        public DelegateCommand 刪除按鈕Command { get; set; }
        public DelegateCommand 儲存按鈕Command { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public readonly IPageDialogService _dialogService;

        差旅費用項目ViewModel para點選工作日報表項目;
        新增或修改Enum para新增或修改 = 新增或修改Enum.修改;
        差旅費用紀錄維護動作內容 foo差旅費用紀錄維護動作內容;
        #endregion

        #region Constructor 建構式
        public 差旅費用申請紀錄修改PageViewModel(INavigationService navigationService, IEventAggregator eventAggregator,
            IPageDialogService dialogService)
        {

            #region 相依性服務注入的物件

            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令 
            刪除按鈕Command = new DelegateCommand(async () =>
            {
                var fooResult = await _dialogService.DisplayAlertAsync("確認", "您確定要刪除這筆紀錄嗎?", "確定", "取消");
                if (fooResult == true)
                {
                    foo差旅費用紀錄維護動作內容 = new 差旅費用紀錄維護動作內容
                    {
                        差旅費用項目 = para點選工作日報表項目,
                        新增或修改Enum = 新增或修改Enum.刪除
                    };
                    _eventAggregator.GetEvent<差旅費用紀錄維護動作Event>().Publish(foo差旅費用紀錄維護動作內容);
                    var fooPara = new NavigationParameters();
                    fooPara.Add("差旅費用紀錄維護動作內容", foo差旅費用紀錄維護動作內容);
                    await _navigationService.GoBackAsync(fooPara);
                }
            });
            儲存按鈕Command = new DelegateCommand(async () =>
            {
                if (para新增或修改 == 新增或修改Enum.新增)
                {
                    foo差旅費用紀錄維護動作內容 = new 差旅費用紀錄維護動作內容
                    {
                        差旅費用項目 = 差旅費用項目紀錄,
                        新增或修改Enum = 新增或修改Enum.新增,
                    };
                    _eventAggregator.GetEvent<差旅費用紀錄維護動作Event>().Publish(foo差旅費用紀錄維護動作內容);
                }
                else
                {
                    foo差旅費用紀錄維護動作內容 = new 差旅費用紀錄維護動作內容
                    {
                        差旅費用項目 = 差旅費用項目紀錄,
                        新增或修改Enum = 新增或修改Enum.修改,
                    };
                    _eventAggregator.GetEvent<差旅費用紀錄維護動作Event>().Publish(foo差旅費用紀錄維護動作內容);
                }
                var fooPara = new NavigationParameters();
                fooPara.Add("差旅費用紀錄維護動作內容", foo差旅費用紀錄維護動作內容);
                await _navigationService.GoBackAsync(fooPara);
            });
            #endregion
        }

        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            #region 取回頁面傳遞的參數
            if (parameters.ContainsKey("新增或修改") == true)
            {
                para新增或修改 = (新增或修改Enum)parameters["新增或修改"];
                //foo新增或修改 = (新增或修改Enum)Enum.Parse(typeof(新增或修改Enum), parameters["新增或修改"].ToString());

                if (para新增或修改 == 新增或修改Enum.新增)
                {
                    Title = "差旅費用新增";
                    差旅費用項目紀錄 = new 差旅費用項目ViewModel();
                    // 因為在新增模式，所以，將刪除按鈕隱藏起來
                    儲存按鈕的ColumnSpan = 2;
                    儲存按鈕的ColumnID = 0;
                    儲存按鈕Margin = new Thickness(0, 0, 0, 0);
                }
                else if (para新增或修改 == 新增或修改Enum.修改)
                {
                    Title = "差旅費用修改";
                    儲存按鈕的ColumnSpan = 1;
                    儲存按鈕的ColumnID = 1;
                    儲存按鈕Margin = new Thickness(5, 0, 0, 0);
                    if (parameters.ContainsKey("點選工作日報表項目") == true)
                    {
                        para點選工作日報表項目 = parameters["點選工作日報表項目"] as 差旅費用項目ViewModel;
                        差旅費用項目紀錄 = para點選工作日報表項目.Clone() as 差旅費用項目ViewModel;
                    }
                    else
                    {
                        差旅費用項目紀錄 = new 差旅費用項目ViewModel();
                        para點選工作日報表項目 = new 差旅費用項目ViewModel();
                    }
                }
            }
            #endregion

            Init();
        }
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
        }
        #endregion

    }
}
