using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;
using Prism.Services;
using XFDoggy.Models;
using XFDoggy.Repositories;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using XFDoggy.Helpers;

namespace XFDoggy.ViewModels
{
    public class 我要請假記錄修改PageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        請假紀錄Repository foo請假紀錄Repository = new 請假紀錄Repository();
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 請假紀錄項目
        private 請假紀錄項目ViewModel _請假紀錄項目;
        /// <summary>
        /// 請假紀錄項目
        /// </summary>
        public 請假紀錄項目ViewModel 請假紀錄項目
        {
            get { return this._請假紀錄項目; }
            set { this.SetProperty(ref this._請假紀錄項目, value); }
        }
        #endregion

        #region 假別清單
        private ObservableCollection<string> _假別清單 = new ObservableCollection<string>();
        /// <summary>
        /// 假別清單
        /// </summary>
        public ObservableCollection<string> 假別清單
        {
            get { return _假別清單; }
            set { SetProperty(ref _假別清單, value); }
        }
        #endregion

        #region 點選假別
        private string _點選假別;
        /// <summary>
        /// 點選假別
        /// </summary>
        public string 點選假別
        {
            get { return this._點選假別; }
            set { this.SetProperty(ref this._點選假別, value); }
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

        #region 顯示刪除按鈕
        private bool _顯示刪除按鈕;
        /// <summary>
        /// 顯示刪除按鈕
        /// </summary>
        public bool 顯示刪除按鈕
        {
            get { return this._顯示刪除按鈕; }
            set { this.SetProperty(ref this._顯示刪除按鈕, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        新增或修改Enum 新增或修改 = 新增或修改Enum.修改;
        string fooID = "";
        請假紀錄項目 foo請假紀錄項目;
        LeaveRecord foo請假紀錄;

        public DelegateCommand 刪除按鈕Command { get; set; }
        public DelegateCommand 儲存按鈕Command { get; set; }
        public DelegateCommand 取消按鈕Command { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public readonly IPageDialogService _dialogService;
        #endregion

        #region Constructor 建構式
        public 我要請假記錄修改PageViewModel(INavigationService navigationService, IEventAggregator eventAggregator,
            IPageDialogService dialogService)
        {
            //
            #region 相依性服務注入的物件

            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令 
            刪除按鈕Command = new DelegateCommand(async () =>
            {
                var fooAnswer = await _dialogService.DisplayAlertAsync("警告", "您確定刪除這筆請假記錄", "確定", "取消");
                if (fooAnswer == true)
                {
                    foo請假紀錄 = await MainHelper.請假紀錄Manager.LookupAsync(請假紀錄項目.ID);
                    if (foo請假紀錄 != null)
                    {
                        await MainHelper.請假紀錄Manager.DeleteAsync(foo請假紀錄);
                    }
                    await _navigationService.GoBackAsync();
                }
            });
            儲存按鈕Command = new DelegateCommand(async () =>
            {
                var fooCheck = await Check資料完整性();
                if (fooCheck == false)
                {
                    return;
                }

                if (新增或修改 == 新增或修改Enum.新增)
                {
                    foo請假紀錄 = new LeaveRecord
                    {
                        假別 = 點選假別,
                        申請人 = 請假紀錄項目.申請人,
                        職務代理人 = 請假紀錄項目.職務代理人,
                        請假日期 = 請假紀錄項目.請假日期,
                        請假時數 = 請假紀錄項目.請假時數,
                        請假理由 = 請假紀錄項目.請假理由,
                        開始時間 = 請假紀錄項目.開始時間,
                    };
                    await MainHelper.請假紀錄Manager.InsertAsync(foo請假紀錄);

                    await _navigationService.GoBackAsync();
                }
                else
                {
                    foo請假紀錄 = await MainHelper.請假紀錄Manager.LookupAsync(請假紀錄項目.ID);
                    if (foo請假紀錄 != null)
                    {
                        foo請假紀錄.假別 = 點選假別;
                        foo請假紀錄.申請人 = 請假紀錄項目.申請人;
                        foo請假紀錄.職務代理人 = 請假紀錄項目.職務代理人;
                        foo請假紀錄.請假日期 = 請假紀錄項目.請假日期;
                        foo請假紀錄.請假時數 = 請假紀錄項目.請假時數;
                        foo請假紀錄.請假理由 = 請假紀錄項目.請假理由;
                        foo請假紀錄.開始時間 = 請假紀錄項目.開始時間;
                        await MainHelper.請假紀錄Manager.UpdateAsync(foo請假紀錄);
                    }
                    else
                    {
                        return;
                    }

                    await _navigationService.GoBackAsync();
                }

                await _navigationService.GoBackAsync();
            });

            取消按鈕Command = new DelegateCommand(async () =>
            {
                var fooAnswer = await _dialogService.DisplayAlertAsync("警告", "您確定取消這筆請假記錄", "確定", "取消");
                if (fooAnswer == true)
                {
                    await _navigationService.GoBackAsync();
                }
            });
            #endregion
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("ID") == true)
            {
                fooID = parameters["ID"] as string;
                新增或修改 = 新增或修改Enum.修改;
                Title = "請假記錄修改";
                顯示刪除按鈕 = true;
            }
            else
            {
                fooID = "";
                新增或修改 = 新增或修改Enum.新增;
                Title = "請假記錄新增";
                顯示刪除按鈕 = false;
            }
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
            #region 假別清單項目初始化
            假別清單.Clear();
            假別清單.Add("請選擇");
            假別清單.Add("特休假");
            假別清單.Add("事假");
            假別清單.Add("病假");
            #endregion

            await foo請假紀錄Repository.Read();

            if (string.IsNullOrEmpty(fooID) == true)
            {
                請假紀錄項目 = new 請假紀錄項目ViewModel();
                點選假別 = 假別清單[0];
            }
            else
            {
                foo請假紀錄 = await MainHelper.請假紀錄Manager.LookupAsync(fooID);

                //foo請假紀錄項目 = foo請假紀錄Repository.請假紀錄.FirstOrDefault(x => x.ID == fooID);
                if (foo請假紀錄 == null)
                {
                    請假紀錄項目 = new 請假紀錄項目ViewModel();
                    點選假別 = 假別清單[0];
                }
                else
                {
                    請假紀錄項目 = new 請假紀錄項目ViewModel
                    {
                        ID = foo請假紀錄.Id,
                        假別 = foo請假紀錄.假別,
                        申請人 = foo請假紀錄.申請人,
                        職務代理人 = foo請假紀錄.職務代理人,
                        請假日期 = foo請假紀錄.請假日期,
                        請假時數 = foo請假紀錄.請假時數,
                        請假理由 = foo請假紀錄.請假理由,
                        開始時間 = foo請假紀錄.開始時間,
                    };

                    var fooObj = 假別清單.FirstOrDefault(x => x == 請假紀錄項目.假別);
                    if (fooObj != null)
                    {
                        點選假別 = fooObj;
                    }
                    else
                    {
                        點選假別 = 假別清單[0];
                    }
                }
            }
        }

        private async Task<bool> Check資料完整性()
        {
            if (點選假別 == 假別清單[0])
            {
                await _dialogService.DisplayAlertAsync("警告", "您尚未選擇請假類別", "確定");
                return false;
            }

            return true;
        }
        #endregion

    }
}
