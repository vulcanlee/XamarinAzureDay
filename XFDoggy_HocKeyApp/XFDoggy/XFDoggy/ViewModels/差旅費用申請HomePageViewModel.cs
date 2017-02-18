using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Collections.ObjectModel;
using XFDoggy.Models;
using Prism.Events;
using Microsoft.WindowsAzure.MobileServices;
using XFDoggy.Helpers;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class 差旅費用申請HomePageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        // 取得 Azure Mobile App 中的 差旅費用 資料表物件
        IMobileServiceTable<BusinessTripExpense> 差旅費用Table = MainHelper.client.GetTable<BusinessTripExpense>();
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)
        #region 差旅費用項目清單
        private ObservableCollection<差旅費用項目ViewModel> _差旅費用項目清單 = new ObservableCollection<差旅費用項目ViewModel>();
        /// <summary>
        /// 工作日報表項目清單
        /// </summary>
        public ObservableCollection<差旅費用項目ViewModel> 差旅費用項目清單
        {
            get { return _差旅費用項目清單; }
            set { SetProperty(ref _差旅費用項目清單, value); }
        }
        #endregion

        #region 點選差旅費用項目
        private 差旅費用項目ViewModel _點選差旅費用項目;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public 差旅費用項目ViewModel 點選差旅費用項目
        {
            get { return this._點選差旅費用項目; }
            set { this.SetProperty(ref this._點選差旅費用項目, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        BusinessTripExpense foo差旅費用;

        public DelegateCommand 點選差旅費用項目Command { get; set; }
        public DelegateCommand 新增按鈕Command { get; set; }
        public DelegateCommand 我要崩壞Command { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region Constructor 建構式
        public 差旅費用申請HomePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {

            #region 相依性服務注入的物件

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            點選差旅費用項目Command = new DelegateCommand(async () =>
            {
                #region 建立要傳遞到下個頁面的參數
                var fooNavigationParameters = new NavigationParameters();
                fooNavigationParameters.Add("點選工作日報表項目", 點選差旅費用項目);
                fooNavigationParameters.Add("新增或修改", 新增或修改Enum.修改);
                #endregion

                //點選工作日報表項目 = null;

                await _navigationService.NavigateAsync("差旅費用申請紀錄修改Page", fooNavigationParameters);
            });

            新增按鈕Command = new DelegateCommand(async () =>
            {
                #region 建立要傳遞到下個頁面的參數
                var fooNavigationParameters = new NavigationParameters();
                fooNavigationParameters.Add("點選工作日報表項目", new 差旅費用項目ViewModel());
                fooNavigationParameters.Add("新增或修改", 新增或修改Enum.新增);
                #endregion

                await _navigationService.NavigateAsync("差旅費用申請紀錄修改Page", fooNavigationParameters);
            });

            我要崩壞Command = new DelegateCommand(() =>
            {
                throw new Exception("使用者自己選擇要崩潰了");
            });
            #endregion

            #region 事件聚合器訂閱
            _eventAggregator.GetEvent<差旅費用紀錄維護動作Event>().Subscribe(async x =>
            {
                switch (x.新增或修改Enum)
                {
                    case 新增或修改Enum.新增:
                        #region Azure 行動應用服務的新增
                        foo差旅費用 = new BusinessTripExpense
                        {
                            備註 = x.差旅費用項目.備註,
                            出差日期 = x.差旅費用項目.出差日期,
                            國內外 = x.差旅費用項目.國內外,
                            地點 = x.差旅費用項目.地點,
                            是否有單據 = x.差旅費用項目.是否有單據,
                            費用 = x.差旅費用項目.費用,
                            項目名稱 = x.差旅費用項目.項目名稱,
                            類型 = x.差旅費用項目.類型,
                        };
                        await 差旅費用Table.InsertAsync(foo差旅費用);
                        await Init();
                        #endregion
                        break;
                    case 新增或修改Enum.修改:
                        #region 更新欄位資料
                        var fooObj = 差旅費用項目清單.FirstOrDefault(z => z.ID == x.差旅費用項目.ID);
                        if (fooObj != null)
                        {
                            var fooIdx = 差旅費用項目清單.IndexOf(fooObj);
                            差旅費用項目清單[fooIdx] = x.差旅費用項目;
                        }

                        #region Azure 行動應用服務的新增
                        foo差旅費用 = await 差旅費用Table.LookupAsync(x.差旅費用項目.ID);
                        foo差旅費用.備註 = x.差旅費用項目.備註;
                        foo差旅費用.出差日期 = x.差旅費用項目.出差日期;
                        foo差旅費用.國內外 = x.差旅費用項目.國內外;
                        foo差旅費用.地點 = x.差旅費用項目.地點;
                        foo差旅費用.是否有單據 = x.差旅費用項目.是否有單據;
                        foo差旅費用.費用 = x.差旅費用項目.費用;
                        foo差旅費用.項目名稱 = x.差旅費用項目.項目名稱;
                        foo差旅費用.類型 = x.差旅費用項目.類型;

                        await 差旅費用Table.UpdateAsync(foo差旅費用);
                        #endregion
                        #endregion
                        break;
                    case 新增或修改Enum.刪除:
                        var fooObjDel = 差旅費用項目清單.FirstOrDefault(z => z.ID == x.差旅費用項目.ID);
                        if (fooObjDel != null)
                        {
                            差旅費用項目清單.Remove(fooObjDel);
                        }

                        #region Azure 行動應用服務的新增
                        foo差旅費用 = await 差旅費用Table.LookupAsync(x.差旅費用項目.ID);
                        await 差旅費用Table.DeleteAsync(foo差旅費用);
                        #endregion
                        break;
                    default:
                        break;
                }
            });
            #endregion
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("差旅費用紀錄維護動作內容") == false)
            {
                await Init();
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
        /// 進行要顯示資料的初始化
        /// </summary>
        private async Task Init()
        {
            差旅費用項目ViewModel foo差旅費用項目;

            差旅費用項目清單.Clear();

            #region 呼叫 Azure 行動應用後台，取得最新後台資料表的清單
            var fooList = await 差旅費用Table.OrderByDescending(x => x.出差日期).ToListAsync();
            foreach (var item in fooList)
            {
                foo差旅費用項目 = new 差旅費用項目ViewModel
                {
                    ID = item.Id,
                    出差日期 = item.出差日期,
                    項目名稱 = item.項目名稱,
                    地點 = item.地點,
                    類型 = item.類型,
                    是否有單據 = item.是否有單據,
                    國內外 = item.國內外,
                    費用 = item.費用,
                    備註 = item.備註,
                };
                差旅費用項目清單.Add(foo差旅費用項目);
            }
            #endregion
        }
        #endregion

    }
}
