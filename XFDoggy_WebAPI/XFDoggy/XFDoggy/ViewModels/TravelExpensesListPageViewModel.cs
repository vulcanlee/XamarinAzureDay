using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Collections.ObjectModel;
using XFDoggy.Helps;
using XFDoggy.Models;
using Prism.Events;
using XFDoggy.Infrastructure;

namespace XFDoggy.ViewModels
{
    public class TravelExpensesListPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand MyDataClickedCommand { get; private set; }
        public DelegateCommand 更新資料Command { get; private set; }
        public DelegateCommand 新增Command { get; private set; }

        #region MyData
        private ObservableCollection<TravelExpensesListItemViewModel> myData = new ObservableCollection<TravelExpensesListItemViewModel>();
        /// <summary>
        /// MyData
        /// </summary>
        public ObservableCollection<TravelExpensesListItemViewModel> MyData
        {
            get { return this.myData; }
            set { this.SetProperty(ref this.myData, value); }
        }
        #endregion


        #region MyDataSelected
        private TravelExpensesListItemViewModel myDataSelected;
        /// <summary>
        /// MyDataSelected
        /// </summary>
        public TravelExpensesListItemViewModel MyDataSelected
        {
            get { return this.myDataSelected; }
            set { this.SetProperty(ref this.myDataSelected, value); }
        }
        #endregion


        #region IsBusy
        private bool isBusy;
        /// <summary>
        /// IsBusy
        /// </summary>
        public bool IsBusy
        {
            get { return this.isBusy; }
            set { this.SetProperty(ref this.isBusy, value); }
        }
        #endregion


        public TravelExpensesListPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;

            _eventAggregator = eventAggregator;
            MyDataClickedCommand = new DelegateCommand(MyDataClicked);
            更新資料Command = new DelegateCommand(更新資料);
            新增Command = new DelegateCommand(新增);

            _eventAggregator.GetEvent<CRUDEvent>().Subscribe(CRUD處理事件);
        }

        private void CRUD處理事件(string obj)
        {
            if(obj == "Refresh")
            {
                重新整理資料();
            }
        }

        private async void 新增()
        {
            var fooPara = new NavigationParameters();
            fooPara.Add("模式", "新增");
            fooPara.Add("TravelExpense", new TravelExpense
            {
                Account = AppData.Account,
                Category = "",
                Domestic = true,
                Expense = 0,
                HasDocument = false,
                Location = "",
                Memo = "",
                Title = "",
                TravelDate = DateTime.Now
            });
            await _navigationService.NavigateAsync("TravelExpensesPage", fooPara);
        }

        private async void MyDataClicked()
        {
            var fooData = AppData.AllTravelExpense.FirstOrDefault(x => x.ID == MyDataSelected.ID);
            var fooPara = new NavigationParameters();
            fooPara.Add("模式", "修改");
            fooPara.Add("TravelExpense", new TravelExpense
            {
                ID = fooData.ID,
                Account = AppData.Account,
                Category = fooData.Category,
                Domestic = fooData.Domestic,
                Expense = fooData.Expense,
                HasDocument = fooData.HasDocument,
                Location = fooData.Location,
                Memo = fooData.Memo,
                Title = fooData.Title,
                TravelDate = fooData.TravelDate,
            });
            await _navigationService.NavigateAsync("TravelExpensesPage", fooPara);
        }

        private async void 更新資料()
        {
            var fooItems = (await AppData.DataService.GetTravelExpensesAsync(AppData.Account)).ToList();
            AppData.AllTravelExpense = fooItems;
            重新整理資料();
            IsBusy = false;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            重新整理資料();
        }

        public void 重新整理資料()
        {
            MyData.Clear();
            foreach (var item in AppData.AllTravelExpense)
            {
                MyData.Add(new TravelExpensesListItemViewModel
                {
                    ID = item.ID,
                    Title = item.Title,
                    TravelDate = item.TravelDate,
                });
            }
        }
    }
}
