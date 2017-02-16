using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XFDoggy.Helps;
using XFDoggy.Infrastructure;
using XFDoggy.Models;
using System.Threading.Tasks;
using Prism.Services;

namespace XFDoggy.ViewModels
{
    public class TravelExpensesPageViewModel : BindableBase, INavigationAware
    {
        #region ViewModel Property

        #region ID
        private int id;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.SetProperty(ref this.id, value); }
        }
        #endregion

        #region Account
        private string account;
        /// <summary>
        /// Account
        /// </summary>
        public string Account
        {
            get { return this.account; }
            set { this.SetProperty(ref this.account, value); }
        }
        #endregion

        #region TravelDate
        private DateTime travelDate = DateTime.Now;
        /// <summary>
        /// TravelDate
        /// </summary>
        public DateTime TravelDate
        {
            get { return this.travelDate; }
            set { this.SetProperty(ref this.travelDate, value); }
        }
        #endregion

        #region Category
        private string category;
        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get { return this.category; }
            set { this.SetProperty(ref this.category, value); }
        }
        #endregion

        #region Title
        private string title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }
        #endregion

        #region Location
        private string location;
        /// <summary>
        /// Location
        /// </summary>
        public string Location
        {
            get { return this.location; }
            set { this.SetProperty(ref this.location, value); }
        }
        #endregion

        #region Expense
        private double expense;
        /// <summary>
        /// Expense
        /// </summary>
        public double Expense
        {
            get { return this.expense; }
            set { this.SetProperty(ref this.expense, value); }
        }
        #endregion

        #region Memo
        private string memo;
        /// <summary>
        /// Memo
        /// </summary>
        public string Memo
        {
            get { return this.memo; }
            set { this.SetProperty(ref this.memo, value); }
        }
        #endregion

        #region Domestic
        private bool domestic;
        /// <summary>
        /// Domestic
        /// </summary>
        public bool Domestic
        {
            get { return this.domestic; }
            set { this.SetProperty(ref this.domestic, value); }
        }
        #endregion

        #region HasDocument
        private bool hasDocument;
        /// <summary>
        /// HasDocument
        /// </summary>
        public bool HasDocument
        {
            get { return this.hasDocument; }
            set { this.SetProperty(ref this.hasDocument, value); }
        }
        #endregion

        #region Updatetime
        private DateTime updatetime;
        /// <summary>
        /// Updatetime
        /// </summary>
        public DateTime Updatetime
        {
            get { return this.updatetime; }
            set { this.SetProperty(ref this.updatetime, value); }
        }
        #endregion


        #region CategoryList
        private List<string> categoryList;
        /// <summary>
        /// CategoryList
        /// </summary>
        public List<string> CategoryList
        {
            get { return this.categoryList; }
            set { this.SetProperty(ref this.categoryList, value); }
        }
        #endregion


        #region ShowDeleteMode
        private bool isDeleteMode;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public bool ShowDeleteMode
        {
            get { return this.isDeleteMode; }
            set { this.SetProperty(ref this.isDeleteMode, value); }
        }
        #endregion

        #endregion

        public string 紀錄處理模式 { get; set; }
        private readonly INavigationService _navigationService;

        public readonly IPageDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand 儲存Command { get; private set; }
        public DelegateCommand 刪除Command { get; private set; }
        public DelegateCommand 取消Command { get; private set; }

        public delegate string 讀取Picker選擇項目Del();
        public 讀取Picker選擇項目Del foo讀取Picker選擇項目;
        public Action<string> foo分類Picker初始化;
        public Action<string> foo頁面Title初始化;
        TravelExpense fooTravelExpense;

        public TravelExpensesPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator,
            IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
            儲存Command = new DelegateCommand(儲存);
            刪除Command = new DelegateCommand(刪除);
            取消Command = new DelegateCommand(取消);
        }

        private async void 取消()
        {
            if (檢查資料是否有異動() == true)
            {
                var fooAnswer = await _dialogService.DisplayAlertAsync("警告", "資料已經有異動，您確定要取消此次資料輸入嗎?", "是", "否");
                if(fooAnswer == true)
                {
                    await _navigationService.GoBackAsync();
                }
            }
            else
            {
                await _navigationService.GoBackAsync();
            }
        }

        private bool 檢查資料是否有異動()
        {
            bool fooIsChange = false;

            Category = foo讀取Picker選擇項目();
            if (fooTravelExpense.Category != Category)
            {
                fooIsChange = true;
            }
            else if (fooTravelExpense.Domestic != Domestic)
            {
                fooIsChange = true;
            }
            else if (fooTravelExpense.Expense != Expense)
            {
                fooIsChange = true;
            }
            else if (fooTravelExpense.HasDocument != HasDocument)
            {
                fooIsChange = true;
            }
            else if (fooTravelExpense.Location != Location)
            {
                fooIsChange = true;
            }
            else if (fooTravelExpense.Memo != Memo)
            {
                fooIsChange = true;
            }
            else if (fooTravelExpense.Title != Title)
            {
                fooIsChange = true;
            }
            else if (fooTravelExpense.TravelDate.Date != TravelDate.Date)
            {
                fooIsChange = true;
            }
            return fooIsChange;
        }

        private async void 刪除()
        {
            await AppData.DataService.DeleteTravelExpensesAsync(ID);
            var fooItems = (await AppData.DataService.GetTravelExpensesAsync(AppData.Account)).ToList();
            AppData.AllTravelExpense = fooItems;
            _eventAggregator.GetEvent<CRUDEvent>().Publish("Refresh");
            await _navigationService.GoBackAsync();
        }

        private async void 儲存()
        {
            Category = foo讀取Picker選擇項目();
            fooTravelExpense = new TravelExpense
            {
                ID = ID,
                Account = AppData.Account,
                Category = category,
                Domestic = Domestic,
                Expense = Expense,
                HasDocument = HasDocument,
                Location = Location,
                Memo = Memo,
                Title = Title,
                TravelDate = TravelDate,
                Updatetime = DateTime.Now,
            };
            if (紀錄處理模式 == "新增")
            {
                await AppData.DataService.PostTravelExpensesAsync(fooTravelExpense);
            }
            else
            {
                await AppData.DataService.PutTravelExpensesAsync(fooTravelExpense);
            }
            var fooItems = (await AppData.DataService.GetTravelExpensesAsync(AppData.Account)).ToList();
            AppData.AllTravelExpense = fooItems;
            _eventAggregator.GetEvent<CRUDEvent>().Publish("Refresh");
            await _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            紀錄處理模式 = parameters["模式"] as string;
            fooTravelExpense = parameters["TravelExpense"] as TravelExpense;
            ID = fooTravelExpense.ID;
            Category = fooTravelExpense.Category;
            Domestic = fooTravelExpense.Domestic;
            Expense = fooTravelExpense.Expense;
            HasDocument = fooTravelExpense.HasDocument;
            Location = fooTravelExpense.Location;
            Memo = fooTravelExpense.Memo;
            Title = fooTravelExpense.Title;
            TravelDate = fooTravelExpense.TravelDate;
            if (紀錄處理模式 == "新增")
            {
                ShowDeleteMode = false;
                foo頁面Title初始化("差旅費用 新增");
            }
            else
            {
                ShowDeleteMode = true;
                foo分類Picker初始化(fooTravelExpense.Category);
                foo頁面Title初始化("差旅費用 修改");
            }
        }

        private void Init()
        {
            CategoryList = new List<string>();
            var fooItems = AppData.AllTravelExpensesCategory;
            foreach (var item in fooItems)
            {
                CategoryList.Add(item.Name);
            }
        }
    }
}
