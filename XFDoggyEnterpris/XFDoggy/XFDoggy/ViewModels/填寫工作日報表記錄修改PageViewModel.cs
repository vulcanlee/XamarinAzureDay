using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;
using Prism.Services;
using XFDoggy.Repositories;
using XFDoggy.Models;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class 填寫工作日報表記錄修改PageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        工作日報表Repository foo工作日報表Repository = new 工作日報表Repository();
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 工作日報表項目
        private 工作日報表項目ViewModel _工作日報表項目;
        /// <summary>
        /// 工作日報表項目
        /// </summary>
        public 工作日報表項目ViewModel 工作日報表項目
        {
            get { return this._工作日報表項目; }
            set { this.SetProperty(ref this._工作日報表項目, value); }
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

        public DelegateCommand 儲存按鈕Command { get; set; }
        public DelegateCommand 取消按鈕Command { get; set; }
        public DelegateCommand Can刪除按鈕Command { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public readonly IPageDialogService _dialogService;
        #endregion

        #region Constructor 建構式
        public 填寫工作日報表記錄修改PageViewModel(INavigationService navigationService, IEventAggregator eventAggregator,
            IPageDialogService dialogService)
        {
            #region 相依性服務注入的物件

            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令 
            Can刪除按鈕Command = new DelegateCommand(async () =>
            {
                var fooAnswer = await _dialogService.DisplayAlertAsync("警告", "您確定刪除這筆請假記錄", "確定", "取消");
                if (fooAnswer == true)
                {
                    var fooDelObj = foo工作日報表Repository.工作日報表.FirstOrDefault(x => x.ID == 工作日報表項目.ID);
                    if (fooDelObj != null)
                    {
                        foo工作日報表Repository.工作日報表.Remove(fooDelObj);
                        await foo工作日報表Repository.Write();
                    }
                    _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Publish(true);
                    await _navigationService.GoBackAsync();
                }
            },
            () =>
            {
                //設定這個命令在何種狀態下可以被執行
                return 新增或修改 == 新增或修改Enum.新增 ? false : true;
            }
            );

            儲存按鈕Command = new DelegateCommand(async () =>
            {
                var fooCheck = await Check資料完整性();
                if (fooCheck == false)
                {
                    return;
                }

                if (新增或修改 == 新增或修改Enum.新增)
                {
                    foo工作日報表Repository.工作日報表.Add(new 工作日報表
                    {
                        ID = Guid.NewGuid().ToString(),
                        專案名稱 = 工作日報表項目.專案名稱,
                        工作內容 = 工作日報表項目.工作內容,
                        日期 = 工作日報表項目.日期,
                        處理時間 = 工作日報表項目.處理時間,
                    });
                    await foo工作日報表Repository.Write();
                    _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Publish(true);
                    await _navigationService.GoBackAsync();
                    return;
                }
                else
                {
                    var fooDelObj = foo工作日報表Repository.工作日報表.FirstOrDefault(x => x.ID == 工作日報表項目.ID);
                    if (fooDelObj != null)
                    {
                        fooDelObj.ID = 工作日報表項目.ID;
                        fooDelObj.專案名稱 = 工作日報表項目.專案名稱;
                        fooDelObj.工作內容 = 工作日報表項目.工作內容;
                        fooDelObj.日期 = 工作日報表項目.日期;
                        fooDelObj.處理時間 = 工作日報表項目.處理時間;
                        await foo工作日報表Repository.Write();
                        _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Publish(true);
                        await _navigationService.GoBackAsync();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            });

            取消按鈕Command = new DelegateCommand(async () =>
            {
                var fooAnswer = await _dialogService.DisplayAlertAsync("警告", "您確定取消這筆請假記錄", "確定", "取消");
                if (fooAnswer == true)
                {
                    _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Publish(true);
                    await _navigationService.GoBackAsync();
                }
            });
            #endregion

            _eventAggregator.GetEvent<漢堡按鈕啟動或隱藏Event>().Publish(false);
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
                Title = "工作日報記錄修改";
                顯示刪除按鈕 = true;
            }
            else
            {
                fooID = "";
                新增或修改 = 新增或修改Enum.新增;
                Title = "工作日報記錄新增";
                顯示刪除按鈕 = false;
            }

            // 要求檢查這個命令是否可以被使用
            Can刪除按鈕Command.RaiseCanExecuteChanged();

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
        private async Task Init()
        {
            await foo工作日報表Repository.Read();

            if (string.IsNullOrEmpty(fooID) == true)
            {
                工作日報表項目 = new 工作日報表項目ViewModel();
            }
            else
            {
                var 工作日報表Model = foo工作日報表Repository.工作日報表.FirstOrDefault(x => x.ID == fooID);
                if (工作日報表Model == null)
                {
                    工作日報表項目 = new 工作日報表項目ViewModel();
                }
                else
                {
                    工作日報表項目 = new 工作日報表項目ViewModel
                    {
                        ID = 工作日報表Model.ID,
                        專案名稱 = 工作日報表Model.專案名稱,
                        工作內容 = 工作日報表Model.工作內容,
                        日期 = 工作日報表Model.日期,
                        是否顯示日期區塊 = true,
                        當日累計工時 = 0,
                        處理時間 = 工作日報表Model.處理時間,
                    };
                }
            }
        }

        private async Task<bool> Check資料完整性()
        {
            if (string.IsNullOrEmpty(工作日報表項目.專案名稱) == true)
            {
                await _dialogService.DisplayAlertAsync("警告", "專案名稱 必須要輸入", "確定");
                return false;
            }

            return true;
        }
        #endregion

    }
}
