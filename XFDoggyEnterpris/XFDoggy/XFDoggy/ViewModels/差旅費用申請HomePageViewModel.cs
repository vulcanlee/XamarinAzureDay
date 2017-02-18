using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Collections.ObjectModel;
using XFDoggy.Models;
using Prism.Events;

namespace XFDoggy.ViewModels
{
    public class 差旅費用申請HomePageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)
        #region 工作日報表項目清單
        private ObservableCollection<差旅費用項目ViewModel> _工作日報表項目清單 = new ObservableCollection<差旅費用項目ViewModel>();
        /// <summary>
        /// 工作日報表項目清單
        /// </summary>
        public ObservableCollection<差旅費用項目ViewModel> 工作日報表項目清單
        {
            get { return _工作日報表項目清單; }
            set { SetProperty(ref _工作日報表項目清單, value); }
        }
        #endregion

        #region 點選工作日報表項目
        private 差旅費用項目ViewModel _點選工作日報表項目;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public 差旅費用項目ViewModel 點選工作日報表項目
        {
            get { return this._點選工作日報表項目; }
            set { this.SetProperty(ref this._點選工作日報表項目, value); }
        }
        #endregion

        #endregion

        #region Field 欄位

        public DelegateCommand 點選工作日報表項目Command { get; set; }
        public DelegateCommand 新增按鈕Command { get; set; }

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
            點選工作日報表項目Command = new DelegateCommand(async () =>
            {
                #region 建立要傳遞到下個頁面的參數
                var fooNavigationParameters = new NavigationParameters();
                fooNavigationParameters.Add("點選工作日報表項目", 點選工作日報表項目);
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
            #endregion

            #region 事件聚合器訂閱
            _eventAggregator.GetEvent<差旅費用紀錄維護動作Event>().Subscribe(x =>
            {
                switch (x.新增或修改Enum)
                {
                    case 新增或修改Enum.新增:
                        x.差旅費用項目.ID = Guid.NewGuid().ToString();
                        工作日報表項目清單.Add(x.差旅費用項目);
                        break;
                    case 新增或修改Enum.修改:
                        #region 更新欄位資料
                        var fooObj = 工作日報表項目清單.FirstOrDefault(z => z.ID == x.差旅費用項目.ID);
                        if (fooObj != null)
                        {
                            var fooIdx = 工作日報表項目清單.IndexOf(fooObj);
                            工作日報表項目清單[fooIdx] = x.差旅費用項目;
                            //工作日報表項目清單.Add(x.差旅費用項目);
                            //fooObj.備註 = x.差旅費用項目.備註;
                            //fooObj.出差日期 = x.差旅費用項目.出差日期;
                            //fooObj.國內外 = x.差旅費用項目.國內外;
                            //fooObj.地點 = x.差旅費用項目.地點;
                            //fooObj.是否有單據 = x.差旅費用項目.是否有單據;
                            //fooObj.費用 = x.差旅費用項目.費用;
                            //fooObj.項目名稱 = x.差旅費用項目.項目名稱;
                            //fooObj.類型 = x.差旅費用項目.類型;
                        }
                        #endregion
                        break;
                    case 新增或修改Enum.刪除:
                        var fooObjDel = 工作日報表項目清單.FirstOrDefault(z => z.ID == x.差旅費用項目.ID);
                        if (fooObjDel != null)
                        {
                            工作日報表項目清單.Remove(fooObjDel);
                        }
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

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("差旅費用紀錄維護動作內容") == false)
            {
                Init();
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
        private void Init()
        {
            差旅費用項目ViewModel foo工作日報表項目;

            工作日報表項目清單.Clear();

            foo工作日報表項目 = new 差旅費用項目ViewModel
            {
                ID = Guid.NewGuid().ToString(),
                出差日期 = DateTime.Now.AddDays(-3),
                項目名稱 = "高鐵車票",
                地點 = "台北",
                類型 = "交通費",
                是否有單據 = true,
                國內外 = false,
                費用 = 1490,
                備註 = "台北 -> 左營",
            };
            工作日報表項目清單.Add(foo工作日報表項目);

            foo工作日報表項目 = new 差旅費用項目ViewModel
            {
                ID = Guid.NewGuid().ToString(),
                出差日期 = DateTime.Now,
                項目名稱 = "高鐵車票",
                地點 = "左營",
                類型 = "交通費",
                是否有單據 = true,
                國內外 = false,
                費用 = 1180,
                備註 = "左營 -> 台北",
            };
            工作日報表項目清單.Add(foo工作日報表項目);
        }
        #endregion

    }
}
